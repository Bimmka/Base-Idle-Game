using Features.Animal.Factory.Data;
using Features.Animal.Factory.Scripts;
using Features.Animal.SpawnAnimalBox.Data;
using Features.Animal.SpawnAnimalBox.Scripts;
using Features.Services.Assets;
using UnityEngine;
using Zenject;

namespace Features.Bootstrapp
{
  public class GameSceneInstaller : MonoInstaller
  {
    [SerializeField] private AnimalBoxSettings boxSettings;
    [SerializeField] private AnimalBoxView animalBoxView;
    [SerializeField] private AnimalFactorySettings factorySettings;
    
    public override void InstallBindings()
    {
      BindAssetProvider();
      BindAnimalFactory();
      BindAnimalBox();
      InstantiateAnimalBox();
    }

    private void BindAssetProvider() => 
      Container.Bind<IAssetProvider>().To<AssetProvider>().FromNew().AsSingle();

    private void BindAnimalFactory() => 
      Container.Bind<IAnimalFactory>().To<AnimalFactory>().FromNew().AsSingle().WithArguments(factorySettings);

    private void BindAnimalBox() => 
      Container.Bind<AnimalBox>().To<AnimalBox>().FromNew().AsSingle().WithArguments(boxSettings);

    private void InstantiateAnimalBox()
    {
      Container.InstantiatePrefab(animalBoxView);
    }
  }
}