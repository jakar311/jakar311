import com.company.*;

import javax.swing.*;

public class DodajWindow {
    private JTextField textImie;
    private JTextField textNazwisko;
    private JTextField textAdres;
    private JTextField textKodPocztowy;
    private JTextField textTelefon;
    private JTextField textEmail;
    private JTextField textPesel;
    private JComboBox<? > comboTrasa;
    private JTextField textDorosli;
    private JTextField textDzieci;
    private JComboBox<?> comboKlasa;
    private JComboBox<?> comboBilet;
    private JCheckBox specjalnePotrzebyCheckBox;
    private JCheckBox dodatkowyBagazCheckBox;
    private JCheckBox ubezpieczeniePodrozyCheckBox;
    private JCheckBox przeleciane20000KmCheckBox;
    private JTextField textSumaczesc;
    private JTextField textPodatek;
    private JTextField textSuma;
    private JButton resetujButton;
    private JPanel rootDodaj;
    private JButton Obliczbutton;
    private JButton dodajButton;

    DodajWindow(BiuroPodrozy biuro)
    {
        JFrame frame = new JFrame("Dodaj podróż");
        frame.setContentPane(this.rootDodaj);
        frame.setDefaultCloseOperation(JFrame.DISPOSE_ON_CLOSE);
        frame.pack();
        frame.setVisible(true);
        frame.setSize(600,600);

        resetujButton.addActionListener(e -> {
            textImie.setText("");
            textNazwisko.setText("");
            textAdres.setText("");
            textKodPocztowy.setText("");
            textTelefon.setText("");
            textEmail.setText("");
            textPesel.setText("");
            comboTrasa.setSelectedIndex(0);
            textDorosli.setText("");
            textDzieci.setText("");
            comboKlasa.setSelectedIndex(0);
            comboBilet.setSelectedIndex(0);
            textSuma.setText("");
            textSumaczesc.setText("");
            textPodatek.setText("");
        });
        Obliczbutton.addActionListener(e -> {
            try {
                Podroz p = new Podroz(textImie.getText(), textNazwisko.getText(), textAdres.getText(),
                        textKodPocztowy.getText(), textTelefon.getText(), textEmail.getText(), textPesel.getText(),
                        specjalnePotrzebyCheckBox.isSelected(),
                        ubezpieczeniePodrozyCheckBox.isSelected(),
                        dodatkowyBagazCheckBox.isSelected(),
                        przeleciane20000KmCheckBox.isSelected(),
                        Integer.parseInt(textDorosli.getText()), Integer.parseInt(textDzieci.getText()),
                        Podroz.klasa.valueOf((String)comboKlasa.getSelectedItem()),
                        Podroz.bilet.valueOf((String)comboBilet.getSelectedItem()),
                        Podroz.cel.valueOf((String)comboTrasa.getSelectedItem()));

                double sumaCzesc = p.PoliczSumeCzesciowa();
                textSumaczesc.setText(Double.toString(sumaCzesc));
                textPodatek.setText(Double.toString(Podroz.PoliczPodatek(sumaCzesc)));
                textSuma.setText(Double.toString(p.PoliczKoszt()));
            } catch (ZlyKodPocztowyException ex) {
                JOptionPane.showMessageDialog(frame, "Niepoprawny kod pocztowy");
            } catch (ZlyTelefonException ex) {
                JOptionPane.showMessageDialog(frame, "Niepoprawny numer telefonu");
            } catch (ZlyPeselException ex) {
                JOptionPane.showMessageDialog(frame, "Niepoprawny pesel");
            }
        });
        dodajButton.addActionListener(e -> {
            try {
                Podroz p = new Podroz(textImie.getText(), textNazwisko.getText(), textAdres.getText(),
                        textKodPocztowy.getText(), textTelefon.getText(), textEmail.getText(), textPesel.getText(),
                        specjalnePotrzebyCheckBox.isContentAreaFilled(),
                        ubezpieczeniePodrozyCheckBox.isContentAreaFilled(),
                        dodatkowyBagazCheckBox.isContentAreaFilled(),
                        przeleciane20000KmCheckBox.isContentAreaFilled(),
                        Integer.parseInt(textDorosli.getText()), Integer.parseInt(textDzieci.getText()),
                        Podroz.klasa.valueOf((String)comboKlasa.getSelectedItem()),
                        Podroz.bilet.valueOf((String)comboBilet.getSelectedItem()),
                        Podroz.cel.valueOf((String)comboTrasa.getSelectedItem()));

                biuro.DodajLot(p);
                BiuroPodrozyWindow.refreshPodroze(biuro);
                frame.dispose();

            } catch (ZlyKodPocztowyException ex) {
                JOptionPane.showMessageDialog(frame, "Niepoprawny kod pocztowy");
            } catch (ZlyTelefonException ex) {
                JOptionPane.showMessageDialog(frame, "Niepoprawny numer telefonu");
            } catch (ZlyPeselException ex) {
                JOptionPane.showMessageDialog(frame, "Niepoprawny pesel");
            }
        });
    }
}
