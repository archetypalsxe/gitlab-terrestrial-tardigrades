using UnityEngine;

public class TitleScreenController : MonoBehaviour {

  public TardigradeController tardigradeController;

  void Start() {
    this.tardigradeController.resetOpacity();
  }
}