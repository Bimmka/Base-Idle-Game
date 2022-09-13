using System;
using Features.Services.Assets;
using Features.SpawnAnimalBox.Data;
using UniRx;
using Zenject;

namespace Features.SpawnAnimalBox.Scripts
{
    public class AnimalBox 
    {
        private readonly AnimalBoxSettings settings;
        private readonly IAssetProvider assetProvider;
        private CompositeDisposable disposable = new CompositeDisposable();

        [Inject]
        public AnimalBox(AnimalBoxSettings settings, IAssetProvider assetProvider)
        {
            this.settings = settings;
            this.assetProvider = assetProvider;
        }

        public void StartSpawn()
        {
            Observable
                .Interval(TimeSpan.FromSeconds(settings.SpawnTime))
                .Repeat()
                .Subscribe(next => Spawn())
                .AddTo(disposable);
        }

        public void Disable()
        {
            disposable.Dispose();
        }

        private void Spawn()
        {
            assetProvider.Instantiate(settings.Prefab);
        }
    }
}
