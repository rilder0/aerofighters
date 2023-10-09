using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class PlayerBulletObserver {

    public static Action<int> OnTenBulletChanged;

    public static void TenBulletChanged(int TenBulletMunicao) {

        OnTenBulletChanged?.Invoke(TenBulletMunicao);

    }

    public static Action<int> OnPorcentBulletChanged;

    public static void PorcentBulletChanged(int PorcentBulletMunicao) {

        OnPorcentBulletChanged?.Invoke(PorcentBulletMunicao);
    }
}
