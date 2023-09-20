using UnityEngine;

// 아이템들이 공통으로 구현해야 하는 인터페이스
public interface IItem
{
    void Use(GameObject target);        // 아이템 획득 및 사용 메서드, target은 적용 대상
}
