using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // enemy�� �¾�� ������ ���Ҿ� ���� ��ü�� �ƿ츣�� ���. ��, �����ϴ� Ŭ����
    // 1. �� prefab
    // 2. �¾ ��ġ��
    // 3. �ð� ����
    // 4. �� ���� �¾��

    public GameObject zombiePrefab;
    public GameObject monsterPrefab;
    public GameObject skeletonPrefab;
    public Transform[] Points;
    private float timePrev;
    private float timePrev2;
    private float timePrev3;
    private float spawnTime = 3.0f;
    private int maxCount = 10;
    void Start()
    {
        Points = GameObject.Find("SpawnPoints").GetComponentsInChildren<Transform>();
        //�ڱ� �ڽ��� �����ؼ� �� ���� ������Ʈ�� Ʈ���������� Points �迭�� �� ����

        timePrev = Time.time;
        timePrev2 = Time.time;
        timePrev3 = Time.time;
    }

    void Update()
    {    //����ð� - ���Žð�(= �����ð�) >= 3��
        if(Time.time - timePrev >= spawnTime)
        {
            CreateZombie();
        }

        if(Time.time - timePrev2 > 8.0f)
        {
            //�¾ �Լ� ȣ��
            CreateMonster();
        }

        if (Time.time - timePrev3 > 5.0f)
        {
            //�¾ �Լ� ȣ��
            CreateSkeleton();
        }
    }

    private void CreateZombie()
    {
        int zombieCount = GameObject.FindGameObjectsWithTag("ZOMBIE").Length;

        if (zombieCount < maxCount)
        {
            int randPos = Random.Range(1, Points.Length);
            Instantiate(zombiePrefab, Points[randPos].position, Points[randPos].rotation);

            timePrev = Time.time;
        }

        timePrev = Time.time;
    }

    private void CreateMonster()
    {
        int monsterCount = GameObject.FindGameObjectsWithTag("MONSTER").Length;

        if (monsterCount < maxCount)
        {
            int randPos = Random.Range(1, Points.Length);
            Instantiate(monsterPrefab, Points[randPos].position, Points[randPos].rotation);

            timePrev2 = Time.time;
        }

        timePrev2 = Time.time;
    }

    private void CreateSkeleton()
    {
        int skeletonCount = GameObject.FindGameObjectsWithTag("SKELETON").Length;
        //���̶�Ű���� zombie�±׸� ���� �͵��� ������ ī��Ʈ�ؼ� �ѱ��.

        if (skeletonCount < maxCount)
        {
            int randPos = Random.Range(1, Points.Length);   //�� �ؿ� �ִ°� ��ƾߵǴµ� ��������Ʈ ���������ϱ� 1����
            Instantiate(skeletonPrefab, Points[randPos].position, Points[randPos].rotation);

            timePrev3 = Time.time;
        }

        timePrev3 = Time.time;
    }
}
