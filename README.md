# Rect2Sheet Dataset - Rectangles to Sheet-Metal Solutions

<img width="3805" height="1383" alt="rect2sheet- (5)" src="https://github.com/user-attachments/assets/0162d15f-6358-478a-a0aa-285fa3c4343b" />

## Description

A synthetic and manually verified dataset of **19,231 sheet-metal designs** pairing rectangle layouts with their
sheet-metal solutions, plus a parallel set of discarded examples. Additionally provided are also datasets with 80,028 unvalidated designs.

Built for training and evaluating models that turn tabs into bent parts. Generated with the
SheetGen repository: https://github.com/chriswitt77/SheetGen

The full dataset release is available on Zenodo: https://doi.org/10.5281/zenodo.20834240

Same dataset with extra file types (eg STEP) can be found in the study _C. Wittig Adão, A. Tender, and S. Matthiesen, “SheetGen-DS: A Multi-Representation Dataset of Synthetic Sheet Metal Parts for Data-Driven Design Generation (in progress),” 2026._

## Contents

This repository contains test subsets of the dataset:
- `dataset_test_1`: 30 designs
- `dataset_test_2`: 603 designs

## Recreate this dataset or create your own new dataset

It is easy to regenerate the dataset using the SheetGen repository. The README.md of the SheetGen repo provides instructions for running the pipeline. It can simply be done via a GUI.

With the SheetGen repo, you can also create a dataset with infinite variations of rectangle layouts, tab counts, and solution topologies, and the size of the dataset can be far greater than the Rect2Sheet dataset.

## Contents

| Folder | Contents |
|--------|----------|
| `dataset_json` | Accepted **rectangle / solution / metadata** JSON triples |
| `dataset_discarded_json` | Rejected solutions as JSON |
| `dataset_fs` | Same solutions in FeatureScript form |
| `dataset_discarded_fs` | Rejected solutions as FeatureScript |

Each design is a zero-padded triple:

```text
00001_rectangle.json   # input: rectangle tabs (corner points A/B/C, optional mounts)
00001_solution.json    # target: fold sequence, bends (tabs/points/direction), folded tabs
00001_metadata.json    # id, rectangle_id, num_rectangles, has_mounts, allow_non_90, has_split_tabs
```

## How it was generated

Synthetic pipeline in `src/dataset`, configured via `config/config.yaml`:

1. **Rectangles**: Random connected layouts of 2-4 tabs with varied sizes, gaps, angles
   (including non-90 degrees), and optional mount holes.
2. **Solutions**: The SheetGen engine explores fold topologies and produces candidates;
   manufacturability filters (tool collision, unfolding overlap, thin segments) split them into
   **accepted** vs **discarded**; up to 12 diverse solutions per design are kept. For solutions
   with mounts, input rectangles can also be split into two.
3. **Verification**: The author manually inspected all generated solutions and discarded edge cases (for example designs with too thing parts).
4. **Packaging**: Pairs accepted solutions with their rectangles, strips simulation-only fields,
   and emits clean JSON triples plus FeatureScript.

## Credits

Generated with SheetGen: https://github.com/chriswitt77/SheetGen

Please cite the Rect2Sheet dataset (Zenodo DOI: https://doi.org/10.5281/zenodo.20834240) and the SheetGen repository when used.

Citation (APA):

Tender, A. M., Wittig Adão, C., & Matthiesen, S. (2026). Rect2Sheet: A Dataset of Sheet Metal Connection Designs [Dataset]. Karlsruhe Institute of Technology. https://doi.org/10.5281/zenodo.20834240
