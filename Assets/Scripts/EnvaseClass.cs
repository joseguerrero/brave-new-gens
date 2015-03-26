using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class EnvaseClass : MonoBehaviour {

	private Atributos atributos;

	/*
	static Text txtAtencion;
	static Text txtFortaleza;
	static Text txtHabilidadMotora;
	static Text txtInteligencia;
	static Text txtResiliencia;
	*/

	public static void CreateEnvase ()
	{
		Vector3 posicionInicial = new Vector3 (-8.31f, 7.2f, 0);
		Vector3 direccionInicial = new Vector3 (1, 0, 0);
		GameObject ObjEnvase = GameObject.Find("_frasco");
		GameObject envaseClone = (GameObject)Object.Instantiate (ObjEnvase, posicionInicial, new Quaternion());
		envaseClone.rigidbody.velocity = direccionInicial * ApplicationModel.speedFlask;
		envaseClone.AddComponent<Atributos> ();
		int casta = GenerarRandom (6);
		//int casta = 0;
		envaseClone.GetComponent<Atributos> ().casta = casta;
		envaseClone.AddComponent<SpriteRenderer>();
		// Asigna la imagen de la casta 
		switch (casta) {
		case 0: //Alfa
			envaseClone.GetComponent<SpriteRenderer>().sprite = JuegoClasificacion.letraSprites[0];
			break;
		case 1: //Beta
			envaseClone.GetComponent<SpriteRenderer>().sprite = JuegoClasificacion.letraSprites[1];
			break;
		case 2: // Gamma
			envaseClone.GetComponent<SpriteRenderer>().sprite = JuegoClasificacion.letraSprites[2];
			break;
		case 3: // Delta
			envaseClone.GetComponent<SpriteRenderer>().sprite = JuegoClasificacion.letraSprites[3];
			break;
		case 4: // Epsilon
			envaseClone.GetComponent<SpriteRenderer>().sprite = JuegoClasificacion.letraSprites[4];
			break;
		default:
			break;
		}
		envaseClone.GetComponent<SpriteRenderer>().sortingLayerName="Casta";
		#region old
		/*
		envaseClone.GetComponent<Atributos>().inteligencia = GenerarRandom();
		envaseClone.GetComponent<Atributos>().atencion = GenerarRandom();
		envaseClone.GetComponent<Atributos>().fortaleza = GenerarRandom();
		envaseClone.GetComponent<Atributos>().habilidad = GenerarRandom();
		envaseClone.GetComponent<Atributos>().resiliencia = GenerarRandom();


		txtAtencion = GameObject.Find ("txtAtencion").GetComponent<UnityEngine.UI.Text> ();
		txtFortaleza = GameObject.Find ("txtFortaleza").GetComponent<UnityEngine.UI.Text> ();
		txtHabilidadMotora = GameObject.Find ("txtHabilidadMotora").GetComponent<UnityEngine.UI.Text> ();
		txtInteligencia = GameObject.Find ("txtInteligencia").GetComponent<UnityEngine.UI.Text> ();
		txtResiliencia = GameObject.Find ("txtResiliencia").GetComponent<UnityEngine.UI.Text> ();

		txtAtencion.text = string.Format ("{0}", envaseClone.GetComponent<Atributos>().atencion);
		txtFortaleza.text = string.Format ("{0}", envaseClone.GetComponent<Atributos>().fortaleza);
		txtHabilidadMotora.text = string.Format ("{0}", envaseClone.GetComponent<Atributos>().habilidad);
		txtInteligencia.text = string.Format ("{0}", envaseClone.GetComponent<Atributos>().inteligencia);
		txtResiliencia.text = string.Format ("{0}", envaseClone.GetComponent<Atributos>().resiliencia);
		*/
		#endregion
	}

	/// <summary>
	/// Returns a random integer number between min [inclusive] and max [exclusive] (Read Only).
	/// </summary>
	/// <returns>The random.</returns>
	static int GenerarRandom ()
	{
		return Random.Range (1, 4);
	}

	static int GenerarRandom (int castaTope)
	{
		return Random.Range (0, castaTope);
	}
}

