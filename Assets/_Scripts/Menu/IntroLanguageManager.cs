using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class IntroLanguageManager : MonoBehaviour {
	
	Text introText1;
	Text introText2;
	Text toggle;
	Text continueText;

	public GameObject introText1GO;
	public GameObject introText2GO;
	public GameObject toggleGO;
	public GameObject continueGO;
	public GameObject info;

	void Awake()
	{
		introText1 = introText1GO.GetComponent<Text>();
		introText2 = introText2GO.GetComponent<Text>();
		toggle = toggleGO.GetComponent<Text>();
		continueText = continueGO.GetComponent<Text>();

		info.SetActive(false);
	}

	void Start () 
	{
	
		if(PlayerPrefs.GetString("gameLanguage") == "Polish")
		{
			introText1.text = "Mutacja niezidentyfikowanego wirusa, " +
				"potocznie zwanego  'Skazicielem', " +
				"doprowadziła do rozpowszechnienia się choroby," +
				"która po śmierci zamienia jej nosiciela w abominację. " +
				"Ona, posiada zaś jeden cel - całkowicie zgładzić rasę ludzką." +
				"Mówi się, że stworzenia te chodź przypominają ludzi, są pozbawione jakichkolwiek uczuć. " +
				"Wiele z miast zostało już niemal w całości opanowanych przez te plugawe istoty," +
				"a znalezienie bezpiecznego miejsca graniczny z cudem." +
				"Brak dostępu do mediów uniemożliwia uzyskanie jakichkolwiek informacji czy przypadkiem w " +
				"pobliżu nie znajduje się grupa ''Skażonych''. Atak może więc nadejść w najmniej oczekiwanym momencie.";

			introText2.text = "W mieście 'Eidlliwy' ulokowany jest pewien dom, " +
				"zamieszkały przez podstarzałego człowieka o imieniu Clark. " +
				"Był on jednych z tych ludzi, którzy przez innych nazywani byli dziwakami. " +
				"Od zawsze był na domiar sceptyczny. Wciąż przekonywał sąsiadów, że szykuje się wojna. " +
				"Gromadził zapasy jedzenia, uniezależnił się od dostawcy prądu, montując na dachu panele słoneczne. " +
				"Mówiono również, że w swoim asortymencie posiada nielegalnie zakupioną broń. " +
				"Co do wojny dużo się nie pomylił. Jednak gdy reszta ignorantów snuje się bezdusznie po okolicy, " +
				"on wciąż wyczekuje na lepsze jutro. Podczas pewnej nocy, zapadł w głębszy sen niż zwykle, " +
				"całkowicie zapominając aby wybudzić się i rutynowo sprawdzić czy okolica wciąż jest bezpieczna...";

			toggle.text = "W przyszłości nie pokazuj epilogu";
			continueText.text = "kontynuuj...";
		}
		else 
		{
			introText1.text = "Mutation of the unidentified virus, commonly known as 'Corruptor', " +
				"has lead to the dissemination for the disease that after a death, turns carrier into abomination. " +
				"His only goal is to butcher the human race. These creatures look like humans," +
				"but they are devoid of any emotions. " +
				"Many of the cities were almost entirely dominated by these vile creatures. " +
				"Finding a safe place is almost impossible. " +
				"Lack of access to the media prohibiting any information or accident in the vicinity " +
				"is not a group of 'Corruptors'. The attack may therefore come at the least expected moment.";

			introText2.text = "In 'Eidlliwy' city there is a house, " +
				"inhabited by an aging man named Clark. He was one of those people who were called by the other as 'freak'" +
				". He has always been skeptical. Still tried to convince neighbors, that war is coming. " +
				"He collected food supplies, became independent from the electricity supplier, " +
				"by mounted on the roof a solar panels. It was also said that he is hiding illegally purchased weapon. " +
				"If it comes to war, it was not unduly mistake. But when the rest of the ignorant soullessly wanders around," +
				"he's still waiting for a better tomorrow. During one night, he fell into a deeper sleep than usual, " +
				"completely forgetting to wake up and routinely check whether the area is still safe ...";

			toggle.text = "Do not display epilog again";
			continueText.text = "continue...";
			info.SetActive(true);
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
