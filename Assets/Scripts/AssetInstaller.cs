using SimpleStrategy3D.Abstractions;
using SimpleStrategy3D.UIModels;
using SimpleStrategy3D.Utils;
using UnityEngine;
using UnityEngine.Serialization;
using Zenject;

[CreateAssetMenu(fileName = "AssetInstaller", menuName = "Installers/AssetInstaller")]
public class AssetInstaller : ScriptableObjectInstaller<AssetInstaller>
{
	[SerializeField] private AssetsContext _legacyContext;
    [SerializeField] private Vector3Value _groundClicksRMB;
    [SerializeField] private AttackableValue _attackableClicksRMB;
    [SerializeField] private SelectableValue selectables;

    public override void InstallBindings()
    {
        Container.BindInstances(_legacyContext, _groundClicksRMB, _attackableClicksRMB, selectables);
        Container.Bind<IAwaitable<IAttackable>>()
            .FromInstance(_attackableClicksRMB);
        Container.Bind<IAwaitable<Vector3>>()
             .FromInstance(_groundClicksRMB);
    }

}