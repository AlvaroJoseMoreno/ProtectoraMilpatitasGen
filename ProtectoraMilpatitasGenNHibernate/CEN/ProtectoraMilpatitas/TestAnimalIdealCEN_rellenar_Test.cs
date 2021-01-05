
using System;
using System.Text;
using System.Collections.Generic;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Criterion;
using NHibernate.Exceptions;
using ProtectoraMilpatitasGenNHibernate.Exceptions;
using ProtectoraMilpatitasGenNHibernate.EN.ProtectoraMilpatitas;
using ProtectoraMilpatitasGenNHibernate.CAD.ProtectoraMilpatitas;


/*PROTECTED REGION ID(usingProtectoraMilpatitasGenNHibernate.CEN.ProtectoraMilpatitas_TestAnimalIdeal_rellenar_Test) ENABLED START*/
//  references to other libraries
/*PROTECTED REGION END*/

namespace ProtectoraMilpatitasGenNHibernate.CEN.ProtectoraMilpatitas
{
public partial class TestAnimalIdealCEN
{
public void Rellenar_Test (int p_TestAnimalIdeal, string p_aficionFavorita, string p_personalidad, string p_colorFavorito)
{
        /*PROTECTED REGION ID(ProtectoraMilpatitasGenNHibernate.CEN.ProtectoraMilpatitas_TestAnimalIdeal_rellenar_Test_customized) ENABLED START*/

        TestAnimalIdealEN testAnimalIdealEN = null;

        //Initialized TestAnimalIdealEN
        testAnimalIdealEN = new TestAnimalIdealEN ();
        testAnimalIdealEN.Id = p_TestAnimalIdeal;
        testAnimalIdealEN.AficionFavorita = p_aficionFavorita;
        testAnimalIdealEN.Personalidad = p_personalidad;
        testAnimalIdealEN.ColorFavorito = p_colorFavorito;

        int perro = 0;
        int gato = 0;
        int pez = 0;
        int pajaro = 0;
        int tortuga = 0;
        int geco = 0;
        int conejo = 0;
        int hamster = 0;

        if (p_aficionFavorita.Equals ("Animacion")) {
                conejo = conejo + 1;
        }
        else{
                if (p_aficionFavorita.Equals ("Astrologia")) {
                        tortuga = tortuga + 1;
                }
                else{
                        if (p_aficionFavorita.Equals ("Bailar")) {
                                hamster = hamster + 1;
                        }
                        else{
                                if (p_aficionFavorita.Equals ("Cantar")) {
                                        pajaro = pajaro + 1;
                                }
                                else{
                                        if (p_aficionFavorita.Equals ("Hacer deporte")) {
                                                perro = perro + 1;
                                        }
                                        else{
                                                if (p_aficionFavorita.Equals ("Dibujar")) {
                                                        geco = geco + 1;
                                                }
                                                else{
                                                        if (p_aficionFavorita.Equals ("Leer")) {
                                                                pez = pez + 1;
                                                        }
                                                        else{
                                                                if (p_aficionFavorita.Equals ("Manualidades")) {
                                                                        gato = gato + 1;
                                                                }
                                                        }
                                                }
                                        }
                                }
                        }
                }
        }

        if (p_personalidad.Equals ("Agresiva")) {
                geco = geco + 1;
        }
        else{
                if (p_personalidad.Equals ("Alegre")) {
                        perro = perro + 1;
                }
                else{
                        if (p_personalidad.Equals ("Depresiva")) {
                                hamster = hamster + 1;
                        }
                        else{
                                if (p_personalidad.Equals ("Egocentrica")) {
                                        pez = pez + 1;
                                }
                                else{
                                        if (p_personalidad.Equals ("Inteligente")) {
                                                gato = gato + 1;
                                        }
                                        else{
                                                if (p_personalidad.Equals ("Miedosa")) {
                                                        conejo = conejo + 1;
                                                }
                                                else{
                                                        if (p_personalidad.Equals ("Preocupada")) {
                                                                tortuga = tortuga + 1;
                                                        }
                                                        else{
                                                                if (p_personalidad.Equals ("Valiente")) {
                                                                        pajaro = pajaro + 1;
                                                                }
                                                        }
                                                }
                                        }
                                }
                        }
                }
        }

        if (p_colorFavorito.Equals ("Amarillo")) {
                conejo = conejo + 1;
        }
        else{
                if (p_colorFavorito.Equals ("Azul celeste")) {
                        pez = pez + 1;
                }
                else{
                        if (p_colorFavorito.Equals ("Marron")) {
                                pajaro = pajaro + 1;
                        }
                        else{
                                if (p_colorFavorito.Equals ("Naranja")) {
                                        perro = perro + 1;
                                }
                                else{
                                        if (p_colorFavorito.Equals ("Negro")) {
                                                geco = geco + 1;
                                        }
                                        else{
                                                if (p_colorFavorito.Equals ("Purpura")) {
                                                        hamster = hamster + 1;
                                                }
                                                else{
                                                        if (p_colorFavorito.Equals ("Rojo")) {
                                                                gato = gato + 1;
                                                        }
                                                        else{
                                                                if (p_colorFavorito.Equals ("Verde")) {
                                                                        tortuga = tortuga + 1;
                                                                }
                                                        }
                                                }
                                        }
                                }
                        }
                }
        }

        int[] res = new int[] { perro, gato, pez, pajaro, tortuga, geco, conejo, hamster };
        string[] rest = new string[] { "perro", "gato", "pez", "pajaro", "tortuga", "geco", "conejo", "hamster" };

        int pos = 0;
        int mayor = res [0];

        for (int i = 0; i < res.Length; i = i + 1) {
                if (res [i] >= mayor) {
                        mayor = res [i];
                        pos = i;
                }
        }

        testAnimalIdealEN.Resultado = "Tu mascota ideal es un " + rest [pos];
        //Call to TestAnimalIdealCAD

        _ITestAnimalIdealCAD.Rellenar_Test (testAnimalIdealEN);

        /*PROTECTED REGION END*/
}
}
}
