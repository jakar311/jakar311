import com.company.BiuroPodrozy;
import com.company.Podroz;
import com.company.ZlyKodPocztowyException;
import com.company.ZlyPeselException;
import com.company.ZlyTelefonException;


import javax.swing.*;
import java.sql.SQLException;
import java.util.ArrayList;

public class BiuroPodrozyWindow {
    private JPanel rootPanel;
    private JButton dodajButton;
    private JButton usunButton;
    private JButton sortujButton;
    private JButton sortujPoPESELuButton;
    private JButton wyjdzButton;
    private JButton znajdzButton;
    private JButton resetButton;
    private JComboBox<?> comboLot;
    private JTextField txtfieldNazwa;
    private JScrollPane scrollPanel;
    private JList<Podroz> listPodroze;
    private JButton zapiszButton;
    private JButton wczytajButton;
    private static DefaultListModel<Podroz> listPodrozeModel;

    public BiuroPodrozyWindow() throws ZlyTelefonException, ZlyKodPocztowyException, ZlyPeselException
    {
        JFrame frame = new JFrame("BiuroPodrozyWindow");
        frame.setContentPane(this.rootPanel);
        frame.setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
        frame.pack();
        frame.setVisible(true);
        frame.setSize(600,600);

        BiuroPodrozy biuroPodrozy = new BiuroPodrozy("System biura podrozy");


        listPodrozeModel = new DefaultListModel<>();
        for(Podroz podroz : biuroPodrozy.getLoty())
        {
            listPodrozeModel.addElement(podroz);
        }
        listPodroze.setModel(listPodrozeModel);

        listPodroze.setSelectionMode(ListSelectionModel.SINGLE_INTERVAL_SELECTION);
        listPodroze.setLayoutOrientation(JList.VERTICAL);
        listPodroze.setVisibleRowCount(-1);
        scrollPanel.setHorizontalScrollBarPolicy(JScrollPane.HORIZONTAL_SCROLLBAR_ALWAYS);
        scrollPanel.setVerticalScrollBarPolicy(JScrollPane.VERTICAL_SCROLLBAR_ALWAYS);

        txtfieldNazwa.setText(biuroPodrozy.getNazwa());

        wyjdzButton.addActionListener(e -> System.exit(0));
        dodajButton.addActionListener(e -> {
            new DodajWindow(biuroPodrozy);
            refreshPodroze(biuroPodrozy);
        });
        usunButton.addActionListener(e -> {
            int index = listPodroze.getSelectedIndex();
            if(index >= 0)
            {
                biuroPodrozy.UsunLot(biuroPodrozy.getLoty().get(index));
                refreshPodroze(biuroPodrozy);
            }
        });
        sortujButton.addActionListener(e -> {
            biuroPodrozy.Sortuj();
            refreshPodroze(biuroPodrozy);
        });
        sortujPoPESELuButton.addActionListener(e -> {
            biuroPodrozy.SortujPoPESEL();
            refreshPodroze(biuroPodrozy);
        });
        znajdzButton.addActionListener(e -> {
            String cel = (String)comboLot.getSelectedItem();
            ArrayList<Podroz> loty = biuroPodrozy.WyszukajPodroze(cel);
            listPodrozeModel.removeAllElements();
            for(Podroz l : loty)
            {
                listPodrozeModel.addElement(l);
            }
        });
        resetButton.addActionListener(e -> refreshPodroze(biuroPodrozy));
        zapiszButton.addActionListener(e -> {
            try {
                biuroPodrozy.ZapiszDoBazy(biuroPodrozy);
            } catch (SQLException ex) {
                ex.printStackTrace();
            }
        });
        wczytajButton.addActionListener(e -> {
            try {
                BiuroPodrozy biuro = BiuroPodrozy.OdczytajZBazy();
                biuroPodrozy.a(biuro);
                refreshPodroze(biuroPodrozy);
            } catch (SQLException | ZlyTelefonException | ZlyKodPocztowyException | ZlyPeselException ex) {
                ex.printStackTrace();
            }
        });
    }
    public static void refreshPodroze(BiuroPodrozy biuro)
    {
        listPodrozeModel.removeAllElements();
        for(Podroz p : biuro.getLoty())
        {
            listPodrozeModel.addElement(p);
        }
    }
    public static void main(String[] args) throws ZlyTelefonException, ZlyKodPocztowyException, ZlyPeselException {
        new BiuroPodrozyWindow();
    }
}
