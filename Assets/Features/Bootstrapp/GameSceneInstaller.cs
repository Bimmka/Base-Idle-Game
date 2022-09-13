using Features.Services.Assets;
using Features.SpawnAnimalBox.Data;
using Features.SpawnAnimalBox.Scripts;
using UnityEngine;
using Zenject;

namespace Features.Bootstrapp
{
  public class GameSceneInstaller : MonoInstaller
  {
    [SerializeField] private AnimalBoxSettings boxSettings;
    [SerializeField] private AnimalBoxView animalBoxView;
    
    public override void InstallBindings()
    {
      BindAssetProvider();
      BindAnimalBox();
      InstantiateAnimalBox();
    }

    private void BindAssetProvider() => 
      Container.Bind<IAssetProvider>().To<AssetProvider>().FromNew().AsSingle();

    private void BindAnimalBox() => 
      Container.Bind<AnimalBox>().To<AnimalBox>().FromNew().AsSingle().WithArguments(boxSettings);

    private void InstantiateAnimalBox()
    {
      Container.InstantiatePrefab(animalBoxView);
    }
  }
}