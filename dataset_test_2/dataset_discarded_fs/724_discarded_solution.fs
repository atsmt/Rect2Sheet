FeatureScript 2837;
import(path : "onshape/std/geometry.fs", version : "2837.0");
import(path : "onshape/std/sheetMetalStart.fs", version : "2837.0");
import(path : "onshape/std/sheetMetalFlange.fs", version : "2837.0");
import(path : "onshape/std/sheetMetalTab.fs", version : "2837.0");
annotation { "Feature Type Name" : "hgen-sm-part-sm" }
export const smPart = defineFeature(function(context is Context, id is Id, definition is map)
    precondition { }
    {
        const thickness = 1.0 * millimeter;
        const bendRadius = 1.0 * millimeter;

        // === Root Tab 0 ===
        var sketch0 = newSketchOnPlane(context, id + "sketch0", { "sketchPlane" : plane(vector(200.0, 0.0, 0.0) * millimeter, vector(0.0, 0.0, -1.0), vector(-1.0, 0.0, 0.0)) });
        skPolyline(sketch0, "poly0", { "points" : [vector(0.000000, 0.000000) * millimeter, vector(200.000000, 0.000000) * millimeter, vector(240.000000, 49.705900) * millimeter, vector(250.000000, 49.705900) * millimeter, vector(250.000000, 95.588200) * millimeter, vector(240.000000, 95.588200) * millimeter, vector(200.000000, 160.000000) * millimeter, vector(0.000000, 160.000000) * millimeter, vector(-38.117600, -10.000000) * millimeter, vector(-38.117600, -20.000000) * millimeter, vector(-12.413800, -20.000000) * millimeter, vector(-12.413800, -10.000000) * millimeter, vector(0.000000, 0.000000) * millimeter] });
        skSolve(sketch0);
        opExtractSurface(context, id + "surf0", {
            "faces" : qContainsPoint(qSketchRegion(id + "sketch0"), vector(96.137847, 76.432163, 0.000000) * millimeter),
            "excludeFillets" : false
        });
        sheetMetalStart(context, id + "smStart0", {
            "process" : SMProcessType.CONVERT,
            "partToConvert" : qCreatedBy(id + "surf0", EntityType.BODY),
            "bends" : qNothing(),
            "facesToExclude" : qNothing(),
            "thickness" : thickness,
            "radius" : bendRadius
        });

        // === Child Tab 1 from 0 (one_bend) ===
        // Flange 0->1: bend=90.00deg, zone=10mm
        sheetMetalFlange(context, id + "flange0_1", {
            "edges" : qClosestTo(qOwnedByBody(qBodyType(qCreatedBy(id + "smStart0", EntityType.BODY), BodyType.SOLID), EntityType.EDGE), vector(-50.000000, 72.647050, 0.000000) * millimeter),
            "angleControlType" : SMFlangeAngleControlType.BEND_ANGLE,
            "bendAngle" : 90.000000 * degree,
            "limitType" : SMFlangeBoundingType.BLIND,
            "distance" : 10.000000 * millimeter,
            "flangeAlignment" : SMFlangeAlignment.BEND,
            "autoMiter" : true,
            "useDefaultRadius" : false,
            "bendRadius" : bendRadius,
            "oppositeDirection" : false
        });

        // Remaining polygon for tab 1
        var sketchRem1 = newSketchOnPlane(context, id + "sketchRem1", { "sketchPlane" : plane(vector(-50.0, 10.0, 30.0) * millimeter, vector(-1.0, 0.0, 0.0), vector(0.0, -1.0, 0.0)) });
        skPolyline(sketchRem1, "polyRem1", { "points" : [vector(0.000000, 0.000000) * millimeter, vector(-39.705900, -20.000000) * millimeter, vector(-39.705900, -28.000000) * millimeter, vector(-85.588200, -28.000000) * millimeter, vector(-85.588200, -20.000000) * millimeter, vector(-120.000000, 0.000000) * millimeter, vector(-120.000000, 78.000000) * millimeter, vector(0.000000, 78.000000) * millimeter, vector(0.000000, 0.000000) * millimeter] });
        skSolve(sketchRem1);
        sheetMetalTab(context, id + "smTab1", {
            "tabFaces" : qContainsPoint(qSketchRegion(id + "sketchRem1"), vector(-50.000000, 72.647050, 5.000000) * millimeter),
            "booleanUnionScope" : qClosestTo(qCreatedBy(id + "flange0_1", EntityType.FACE), vector(-50.000000, 72.647050, 5.000000) * millimeter),
            "booleanOffset" : 0.0 * millimeter
        });

        // === Child Tab 3 from 0 (one_bend) ===
        // Flange 0->3: bend=90.00deg, zone=10mm
        sheetMetalFlange(context, id + "flange0_3", {
            "edges" : qClosestTo(qOwnedByBody(qBodyType(qCreatedBy(id + "smStart0", EntityType.BODY), BodyType.SOLID), EntityType.EDGE), vector(225.265700, -20.000000, 0.000000) * millimeter),
            "angleControlType" : SMFlangeAngleControlType.BEND_ANGLE,
            "bendAngle" : 90.000000 * degree,
            "limitType" : SMFlangeBoundingType.BLIND,
            "distance" : 10.000000 * millimeter,
            "flangeAlignment" : SMFlangeAlignment.BEND,
            "autoMiter" : true,
            "useDefaultRadius" : false,
            "bendRadius" : bendRadius,
            "oppositeDirection" : true
        });

        // Remaining polygon for tab 3
        var sketchRem3 = newSketchOnPlane(context, id + "sketchRem3", { "sketchPlane" : plane(vector(290.0, -20.0, 210.0) * millimeter, vector(0.0, 1.0, 0.0), vector(0.0, 0.0, 1.0)) });
        skPolyline(sketchRem3, "polyRem3", { "points" : [vector(0.000000, 0.000000) * millimeter, vector(-200.000000, -77.586200) * millimeter, vector(-208.000000, -77.586200) * millimeter, vector(-208.000000, -51.882400) * millimeter, vector(-200.000000, -51.882400) * millimeter, vector(-160.000000, 0.000000) * millimeter, vector(-160.000000, 140.000000) * millimeter, vector(0.000000, 140.000000) * millimeter, vector(0.000000, 0.000000) * millimeter] });
        skSolve(sketchRem3);
        sheetMetalTab(context, id + "smTab3", {
            "tabFaces" : qContainsPoint(qSketchRegion(id + "sketchRem3"), vector(225.265700, -20.000000, 5.000000) * millimeter),
            "booleanUnionScope" : qClosestTo(qCreatedBy(id + "flange0_3", EntityType.FACE), vector(225.265700, -20.000000, 5.000000) * millimeter),
            "booleanOffset" : 0.0 * millimeter
        });

        // === Child Tab 2 from 1 (two_bend) ===
        // Flange 1->1_1_2: bend=21.43deg, zone=10mm
        sheetMetalFlange(context, id + "flange1_1_1_2a", {
            "edges" : qClosestTo(qOwnedByBody(qBodyType(qCreatedBy(id + "smStart0", EntityType.BODY), BodyType.SOLID), EntityType.EDGE), vector(-50.000000, 70.000000, 110.000000) * millimeter),
            "angleControlType" : SMFlangeAngleControlType.BEND_ANGLE,
            "bendAngle" : 21.433490 * degree,
            "limitType" : SMFlangeBoundingType.BLIND,
            "distance" : 10.000000 * millimeter,
            "flangeAlignment" : SMFlangeAlignment.BEND,
            "autoMiter" : true,
            "useDefaultRadius" : false,
            "bendRadius" : bendRadius,
            "oppositeDirection" : false
        });

        // Remaining polygon for tab 1_1_2
        var wallFace1_1_2a = qClosestTo(qCreatedBy(id + "flange1_1_1_2a", EntityType.FACE), vector(-48.172895, 70.000000, 114.654212) * millimeter);
        var faceN1_1_2a = evPlane(context, { "face" : wallFace1_1_2a }).normal;
        var skN1_1_2a = dot(faceN1_1_2a, vector(-0.930842382, 0.0, 0.3654209351)) >= 0 ? faceN1_1_2a : -faceN1_1_2a;
        var sketchRem1_1_2a = newSketchOnPlane(context, id + "sketchRem1_1_2a", { "sketchPlane" : plane(vector(-46.3458, 130.0, 119.3084) * millimeter, skN1_1_2a, vector(-0.3654209351, 0.0, -0.930842382)) });
        skPolyline(sketchRem1_1_2a, "polyRem1_1_2a", { "points" : [vector(0.000000, 0.000000) * millimeter, vector(7.999974, 0.000000) * millimeter, vector(7.999974, 120.000000) * millimeter, vector(0.000000, 120.000000) * millimeter, vector(47.579469, 140.000000) * millimeter, vector(49.579469, 150.000000) * millimeter, vector(-172.439539, 150.000000) * millimeter, vector(-174.439539, 140.000000) * millimeter, vector(0.000000, 0.000000) * millimeter] });
        skSolve(sketchRem1_1_2a);
        sheetMetalTab(context, id + "smTab1_1_2a", {
            "tabFaces" : qContainsPoint(qSketchRegion(id + "sketchRem1_1_2a"), vector(-48.172895, 130.000000, 114.654212) * millimeter),
            "booleanUnionScope" : wallFace1_1_2a,
            "booleanOffset" : 0.0 * millimeter
        });
        // Flange 1_1_2->2: bend=90.00deg, zone=10mm
        sheetMetalFlange(context, id + "flange1_1_2_2b", {
            "edges" : qClosestTo(qOwnedByBody(qBodyType(qCreatedBy(id + "smStart0", EntityType.BODY), BodyType.SOLID), EntityType.EDGE), vector(-23.167100, -20.000000, 178.351750) * millimeter),
            "angleControlType" : SMFlangeAngleControlType.BEND_ANGLE,
            "bendAngle" : 90.000000 * degree,
            "limitType" : SMFlangeBoundingType.BLIND,
            "distance" : 10.000000 * millimeter,
            "flangeAlignment" : SMFlangeAlignment.BEND,
            "autoMiter" : true,
            "useDefaultRadius" : false,
            "bendRadius" : bendRadius,
            "oppositeDirection" : false
        });

        // Remaining polygon for tab 2
        var sketchRem2b = newSketchOnPlane(context, id + "sketchRem2b", { "sketchPlane" : plane(vector(200.0, -20.0, 50.0) * millimeter, vector(0.0, 1.0, 0.0), vector(-1.0, 0.0, 0.0)) });
        skPolyline(sketchRem2b, "polyRem2b", { "points" : [vector(0.000000, 0.000000) * millimeter, vector(200.000000, 0.000000) * millimeter, vector(261.870615, 24.288558) * millimeter, vector(180.740215, 230.953258) * millimeter, vector(0.000000, 160.000000) * millimeter, vector(0.000000, 0.000000) * millimeter] });
        skSolve(sketchRem2b);
        sheetMetalTab(context, id + "smTab2b", {
            "tabFaces" : qContainsPoint(qSketchRegion(id + "sketchRem2b"), vector(-18.512888, -20.000000, 176.524645) * millimeter),
            "booleanUnionScope" : qClosestTo(qCreatedBy(id + "flange1_1_2_2b", EntityType.FACE), vector(-18.512888, -20.000000, 176.524645) * millimeter),
            "booleanOffset" : 0.0 * millimeter
        });
    });