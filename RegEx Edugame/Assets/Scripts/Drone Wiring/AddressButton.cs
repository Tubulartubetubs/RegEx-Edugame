using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddressButton : MonoBehaviour
{
    public GameObject addressBook;

    public void OpenAddressBook()
    {
        addressBook.SetActive(true);
    }

    public void CloseAddressBook()
    {
        addressBook.SetActive(false);
    }
}
