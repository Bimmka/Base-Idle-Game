using System;
using Features.Animal.Factory.Scripts;
using Features.Animal.SpawnAnimalBox.Data;
using UniRx;
using UnityEngine;
using Zenject;

namespace Features.Animal.SpawnAnimalBox.Scripts
{
    public class AnimalBox 
    {
        private readonly AnimalBoxSettings settings;
        private readonly IAnimalFactory factory;
        private CompositeDisposable disposable = new CompositeDisposable();

        [Inject]
        public AnimalBox(AnimalBoxSettings settings, IAnimalFactory factory)
        {
            this.settings = settings;
            this.factory = factory;
        }

        public void StartSpawn()
        {
            Observable
                .Interval(TimeSpan.FromSeconds(settings.SpawnTime))
                .Repeat()
                .Subscribe(next => Spawn())
                .AddTo(disposable);
        }

        public void StopSpawn()
        {
            disposable.Dispose();
        }

        private void Spawn()
        {
            factory.Spawn(settings.Type, Vector3.zero, Quaternion.identity, null);
        }
    }
}
