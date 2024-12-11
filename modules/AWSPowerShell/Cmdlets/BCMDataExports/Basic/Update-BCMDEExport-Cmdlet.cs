/*******************************************************************************
 *  Copyright 2012-2019 Amazon.com, Inc. or its affiliates. All Rights Reserved.
 *  Licensed under the Apache License, Version 2.0 (the "License"). You may not use
 *  this file except in compliance with the License. A copy of the License is located at
 *
 *  http://aws.amazon.com/apache2.0
 *
 *  or in the "license" file accompanying this file.
 *  This file is distributed on an "AS IS" BASIS, WITHOUT WARRANTIES OR
 *  CONDITIONS OF ANY KIND, either express or implied. See the License for the
 *  specific language governing permissions and limitations under the License.
 * *****************************************************************************
 *
 *  AWS Tools for Windows (TM) PowerShell (TM)
 *
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Text;
using Amazon.PowerShell.Common;
using Amazon.Runtime;
using Amazon.BCMDataExports;
using Amazon.BCMDataExports.Model;

namespace Amazon.PowerShell.Cmdlets.BCMDE
{
    /// <summary>
    /// Updates an existing data export by overwriting all export parameters. All export parameters
    /// must be provided in the UpdateExport request.
    /// </summary>
    [Cmdlet("Update", "BCMDEExport", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the AWSBillingAndCostManagementDataExports UpdateExport API operation.", Operation = new[] {"UpdateExport"}, SelectReturnType = typeof(Amazon.BCMDataExports.Model.UpdateExportResponse))]
    [AWSCmdletOutput("System.String or Amazon.BCMDataExports.Model.UpdateExportResponse",
        "This cmdlet returns a System.String object.",
        "The service call response (type Amazon.BCMDataExports.Model.UpdateExportResponse) can be returned by specifying '-Select *'."
    )]
    public partial class UpdateBCMDEExportCmdlet : AmazonBCMDataExportsClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter S3OutputConfigurations_Compression
        /// <summary>
        /// <para>
        /// <para>The compression type for the data export.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [Alias("Export_DestinationConfigurations_S3Destination_S3OutputConfigurations_Compression")]
        [AWSConstantClassSource("Amazon.BCMDataExports.CompressionOption")]
        public Amazon.BCMDataExports.CompressionOption S3OutputConfigurations_Compression { get; set; }
        #endregion
        
        #region Parameter Export_Description
        /// <summary>
        /// <para>
        /// <para>The description for this specific data export.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Export_Description { get; set; }
        #endregion
        
        #region Parameter Export_ExportArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) for this export.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Export_ExportArn { get; set; }
        #endregion
        
        #region Parameter ExportArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) for this export.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        #else
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyString]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.String ExportArn { get; set; }
        #endregion
        
        #region Parameter S3OutputConfigurations_Format
        /// <summary>
        /// <para>
        /// <para>The file format for the data export.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [Alias("Export_DestinationConfigurations_S3Destination_S3OutputConfigurations_Format")]
        [AWSConstantClassSource("Amazon.BCMDataExports.FormatOption")]
        public Amazon.BCMDataExports.FormatOption S3OutputConfigurations_Format { get; set; }
        #endregion
        
        #region Parameter RefreshCadence_Frequency
        /// <summary>
        /// <para>
        /// <para>The frequency that data exports are updated. The export refreshes each time the source
        /// data updates, up to three times daily.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [Alias("Export_RefreshCadence_Frequency")]
        [AWSConstantClassSource("Amazon.BCMDataExports.FrequencyOption")]
        public Amazon.BCMDataExports.FrequencyOption RefreshCadence_Frequency { get; set; }
        #endregion
        
        #region Parameter Export_Name
        /// <summary>
        /// <para>
        /// <para>The name of this specific data export.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyString]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.String Export_Name { get; set; }
        #endregion
        
        #region Parameter S3OutputConfigurations_OutputType
        /// <summary>
        /// <para>
        /// <para>The output type for the data export.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [Alias("Export_DestinationConfigurations_S3Destination_S3OutputConfigurations_OutputType")]
        [AWSConstantClassSource("Amazon.BCMDataExports.S3OutputType")]
        public Amazon.BCMDataExports.S3OutputType S3OutputConfigurations_OutputType { get; set; }
        #endregion
        
        #region Parameter S3OutputConfigurations_Overwrite
        /// <summary>
        /// <para>
        /// <para>The rule to follow when generating a version of the data export file. You have the
        /// choice to overwrite the previous version or to be delivered in addition to the previous
        /// versions. Overwriting exports can save on Amazon S3 storage costs. Creating new export
        /// versions allows you to track the changes in cost and usage data over time.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [Alias("Export_DestinationConfigurations_S3Destination_S3OutputConfigurations_Overwrite")]
        [AWSConstantClassSource("Amazon.BCMDataExports.OverwriteOption")]
        public Amazon.BCMDataExports.OverwriteOption S3OutputConfigurations_Overwrite { get; set; }
        #endregion
        
        #region Parameter DataQuery_QueryStatement
        /// <summary>
        /// <para>
        /// <para>The query statement.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyString]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [Alias("Export_DataQuery_QueryStatement")]
        public System.String DataQuery_QueryStatement { get; set; }
        #endregion
        
        #region Parameter S3Destination_S3Bucket
        /// <summary>
        /// <para>
        /// <para>The name of the Amazon S3 bucket used as the destination of a data export file.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyString]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [Alias("Export_DestinationConfigurations_S3Destination_S3Bucket")]
        public System.String S3Destination_S3Bucket { get; set; }
        #endregion
        
        #region Parameter S3Destination_S3Prefix
        /// <summary>
        /// <para>
        /// <para>The S3 path prefix you want prepended to the name of your data export.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyString]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [Alias("Export_DestinationConfigurations_S3Destination_S3Prefix")]
        public System.String S3Destination_S3Prefix { get; set; }
        #endregion
        
        #region Parameter S3Destination_S3Region
        /// <summary>
        /// <para>
        /// <para>The S3 bucket Region.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyString]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [Alias("Export_DestinationConfigurations_S3Destination_S3Region")]
        public System.String S3Destination_S3Region { get; set; }
        #endregion
        
        #region Parameter DataQuery_TableConfiguration
        /// <summary>
        /// <para>
        /// <para>The table configuration.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Export_DataQuery_TableConfigurations")]
        public System.Collections.Hashtable DataQuery_TableConfiguration { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'ExportArn'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.BCMDataExports.Model.UpdateExportResponse).
        /// Specifying the name of a property of type Amazon.BCMDataExports.Model.UpdateExportResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "ExportArn";
        #endregion
        
        #region Parameter Force
        /// <summary>
        /// This parameter overrides confirmation prompts to force 
        /// the cmdlet to continue its operation. This parameter should always
        /// be used with caution.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public SwitchParameter Force { get; set; }
        #endregion
        
        protected override void ProcessRecord()
        {
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.ExportArn), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-BCMDEExport (UpdateExport)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.BCMDataExports.Model.UpdateExportResponse, UpdateBCMDEExportCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.DataQuery_QueryStatement = this.DataQuery_QueryStatement;
            #if MODULAR
            if (this.DataQuery_QueryStatement == null && ParameterWasBound(nameof(this.DataQuery_QueryStatement)))
            {
                WriteWarning("You are passing $null as a value for parameter DataQuery_QueryStatement which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.DataQuery_TableConfiguration != null)
            {
                context.DataQuery_TableConfiguration = new Dictionary<System.String, Dictionary<System.String, System.String>>(StringComparer.Ordinal);
                foreach (var hashKey in this.DataQuery_TableConfiguration.Keys)
                {
                    context.DataQuery_TableConfiguration.Add((String)hashKey, (Dictionary<System.String,System.String>)(this.DataQuery_TableConfiguration[hashKey]));
                }
            }
            context.Export_Description = this.Export_Description;
            context.S3Destination_S3Bucket = this.S3Destination_S3Bucket;
            #if MODULAR
            if (this.S3Destination_S3Bucket == null && ParameterWasBound(nameof(this.S3Destination_S3Bucket)))
            {
                WriteWarning("You are passing $null as a value for parameter S3Destination_S3Bucket which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.S3OutputConfigurations_Compression = this.S3OutputConfigurations_Compression;
            #if MODULAR
            if (this.S3OutputConfigurations_Compression == null && ParameterWasBound(nameof(this.S3OutputConfigurations_Compression)))
            {
                WriteWarning("You are passing $null as a value for parameter S3OutputConfigurations_Compression which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.S3OutputConfigurations_Format = this.S3OutputConfigurations_Format;
            #if MODULAR
            if (this.S3OutputConfigurations_Format == null && ParameterWasBound(nameof(this.S3OutputConfigurations_Format)))
            {
                WriteWarning("You are passing $null as a value for parameter S3OutputConfigurations_Format which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.S3OutputConfigurations_OutputType = this.S3OutputConfigurations_OutputType;
            #if MODULAR
            if (this.S3OutputConfigurations_OutputType == null && ParameterWasBound(nameof(this.S3OutputConfigurations_OutputType)))
            {
                WriteWarning("You are passing $null as a value for parameter S3OutputConfigurations_OutputType which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.S3OutputConfigurations_Overwrite = this.S3OutputConfigurations_Overwrite;
            #if MODULAR
            if (this.S3OutputConfigurations_Overwrite == null && ParameterWasBound(nameof(this.S3OutputConfigurations_Overwrite)))
            {
                WriteWarning("You are passing $null as a value for parameter S3OutputConfigurations_Overwrite which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.S3Destination_S3Prefix = this.S3Destination_S3Prefix;
            #if MODULAR
            if (this.S3Destination_S3Prefix == null && ParameterWasBound(nameof(this.S3Destination_S3Prefix)))
            {
                WriteWarning("You are passing $null as a value for parameter S3Destination_S3Prefix which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.S3Destination_S3Region = this.S3Destination_S3Region;
            #if MODULAR
            if (this.S3Destination_S3Region == null && ParameterWasBound(nameof(this.S3Destination_S3Region)))
            {
                WriteWarning("You are passing $null as a value for parameter S3Destination_S3Region which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Export_ExportArn = this.Export_ExportArn;
            context.Export_Name = this.Export_Name;
            #if MODULAR
            if (this.Export_Name == null && ParameterWasBound(nameof(this.Export_Name)))
            {
                WriteWarning("You are passing $null as a value for parameter Export_Name which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.RefreshCadence_Frequency = this.RefreshCadence_Frequency;
            #if MODULAR
            if (this.RefreshCadence_Frequency == null && ParameterWasBound(nameof(this.RefreshCadence_Frequency)))
            {
                WriteWarning("You are passing $null as a value for parameter RefreshCadence_Frequency which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ExportArn = this.ExportArn;
            #if MODULAR
            if (this.ExportArn == null && ParameterWasBound(nameof(this.ExportArn)))
            {
                WriteWarning("You are passing $null as a value for parameter ExportArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            
            // allow further manipulation of loaded context prior to processing
            PostExecutionContextLoad(context);
            
            var output = Execute(context) as CmdletOutput;
            ProcessOutput(output);
        }
        
        #region IExecutor Members
        
        public object Execute(ExecutorContext context)
        {
            var cmdletContext = context as CmdletContext;
            // create request
            var request = new Amazon.BCMDataExports.Model.UpdateExportRequest();
            
            
             // populate Export
            var requestExportIsNull = true;
            request.Export = new Amazon.BCMDataExports.Model.Export();
            System.String requestExport_export_Description = null;
            if (cmdletContext.Export_Description != null)
            {
                requestExport_export_Description = cmdletContext.Export_Description;
            }
            if (requestExport_export_Description != null)
            {
                request.Export.Description = requestExport_export_Description;
                requestExportIsNull = false;
            }
            System.String requestExport_export_ExportArn = null;
            if (cmdletContext.Export_ExportArn != null)
            {
                requestExport_export_ExportArn = cmdletContext.Export_ExportArn;
            }
            if (requestExport_export_ExportArn != null)
            {
                request.Export.ExportArn = requestExport_export_ExportArn;
                requestExportIsNull = false;
            }
            System.String requestExport_export_Name = null;
            if (cmdletContext.Export_Name != null)
            {
                requestExport_export_Name = cmdletContext.Export_Name;
            }
            if (requestExport_export_Name != null)
            {
                request.Export.Name = requestExport_export_Name;
                requestExportIsNull = false;
            }
            Amazon.BCMDataExports.Model.DestinationConfigurations requestExport_export_DestinationConfigurations = null;
            
             // populate DestinationConfigurations
            var requestExport_export_DestinationConfigurationsIsNull = true;
            requestExport_export_DestinationConfigurations = new Amazon.BCMDataExports.Model.DestinationConfigurations();
            Amazon.BCMDataExports.Model.S3Destination requestExport_export_DestinationConfigurations_export_DestinationConfigurations_S3Destination = null;
            
             // populate S3Destination
            var requestExport_export_DestinationConfigurations_export_DestinationConfigurations_S3DestinationIsNull = true;
            requestExport_export_DestinationConfigurations_export_DestinationConfigurations_S3Destination = new Amazon.BCMDataExports.Model.S3Destination();
            System.String requestExport_export_DestinationConfigurations_export_DestinationConfigurations_S3Destination_s3Destination_S3Bucket = null;
            if (cmdletContext.S3Destination_S3Bucket != null)
            {
                requestExport_export_DestinationConfigurations_export_DestinationConfigurations_S3Destination_s3Destination_S3Bucket = cmdletContext.S3Destination_S3Bucket;
            }
            if (requestExport_export_DestinationConfigurations_export_DestinationConfigurations_S3Destination_s3Destination_S3Bucket != null)
            {
                requestExport_export_DestinationConfigurations_export_DestinationConfigurations_S3Destination.S3Bucket = requestExport_export_DestinationConfigurations_export_DestinationConfigurations_S3Destination_s3Destination_S3Bucket;
                requestExport_export_DestinationConfigurations_export_DestinationConfigurations_S3DestinationIsNull = false;
            }
            System.String requestExport_export_DestinationConfigurations_export_DestinationConfigurations_S3Destination_s3Destination_S3Prefix = null;
            if (cmdletContext.S3Destination_S3Prefix != null)
            {
                requestExport_export_DestinationConfigurations_export_DestinationConfigurations_S3Destination_s3Destination_S3Prefix = cmdletContext.S3Destination_S3Prefix;
            }
            if (requestExport_export_DestinationConfigurations_export_DestinationConfigurations_S3Destination_s3Destination_S3Prefix != null)
            {
                requestExport_export_DestinationConfigurations_export_DestinationConfigurations_S3Destination.S3Prefix = requestExport_export_DestinationConfigurations_export_DestinationConfigurations_S3Destination_s3Destination_S3Prefix;
                requestExport_export_DestinationConfigurations_export_DestinationConfigurations_S3DestinationIsNull = false;
            }
            System.String requestExport_export_DestinationConfigurations_export_DestinationConfigurations_S3Destination_s3Destination_S3Region = null;
            if (cmdletContext.S3Destination_S3Region != null)
            {
                requestExport_export_DestinationConfigurations_export_DestinationConfigurations_S3Destination_s3Destination_S3Region = cmdletContext.S3Destination_S3Region;
            }
            if (requestExport_export_DestinationConfigurations_export_DestinationConfigurations_S3Destination_s3Destination_S3Region != null)
            {
                requestExport_export_DestinationConfigurations_export_DestinationConfigurations_S3Destination.S3Region = requestExport_export_DestinationConfigurations_export_DestinationConfigurations_S3Destination_s3Destination_S3Region;
                requestExport_export_DestinationConfigurations_export_DestinationConfigurations_S3DestinationIsNull = false;
            }
            Amazon.BCMDataExports.Model.S3OutputConfigurations requestExport_export_DestinationConfigurations_export_DestinationConfigurations_S3Destination_export_DestinationConfigurations_S3Destination_S3OutputConfigurations = null;
            
             // populate S3OutputConfigurations
            var requestExport_export_DestinationConfigurations_export_DestinationConfigurations_S3Destination_export_DestinationConfigurations_S3Destination_S3OutputConfigurationsIsNull = true;
            requestExport_export_DestinationConfigurations_export_DestinationConfigurations_S3Destination_export_DestinationConfigurations_S3Destination_S3OutputConfigurations = new Amazon.BCMDataExports.Model.S3OutputConfigurations();
            Amazon.BCMDataExports.CompressionOption requestExport_export_DestinationConfigurations_export_DestinationConfigurations_S3Destination_export_DestinationConfigurations_S3Destination_S3OutputConfigurations_s3OutputConfigurations_Compression = null;
            if (cmdletContext.S3OutputConfigurations_Compression != null)
            {
                requestExport_export_DestinationConfigurations_export_DestinationConfigurations_S3Destination_export_DestinationConfigurations_S3Destination_S3OutputConfigurations_s3OutputConfigurations_Compression = cmdletContext.S3OutputConfigurations_Compression;
            }
            if (requestExport_export_DestinationConfigurations_export_DestinationConfigurations_S3Destination_export_DestinationConfigurations_S3Destination_S3OutputConfigurations_s3OutputConfigurations_Compression != null)
            {
                requestExport_export_DestinationConfigurations_export_DestinationConfigurations_S3Destination_export_DestinationConfigurations_S3Destination_S3OutputConfigurations.Compression = requestExport_export_DestinationConfigurations_export_DestinationConfigurations_S3Destination_export_DestinationConfigurations_S3Destination_S3OutputConfigurations_s3OutputConfigurations_Compression;
                requestExport_export_DestinationConfigurations_export_DestinationConfigurations_S3Destination_export_DestinationConfigurations_S3Destination_S3OutputConfigurationsIsNull = false;
            }
            Amazon.BCMDataExports.FormatOption requestExport_export_DestinationConfigurations_export_DestinationConfigurations_S3Destination_export_DestinationConfigurations_S3Destination_S3OutputConfigurations_s3OutputConfigurations_Format = null;
            if (cmdletContext.S3OutputConfigurations_Format != null)
            {
                requestExport_export_DestinationConfigurations_export_DestinationConfigurations_S3Destination_export_DestinationConfigurations_S3Destination_S3OutputConfigurations_s3OutputConfigurations_Format = cmdletContext.S3OutputConfigurations_Format;
            }
            if (requestExport_export_DestinationConfigurations_export_DestinationConfigurations_S3Destination_export_DestinationConfigurations_S3Destination_S3OutputConfigurations_s3OutputConfigurations_Format != null)
            {
                requestExport_export_DestinationConfigurations_export_DestinationConfigurations_S3Destination_export_DestinationConfigurations_S3Destination_S3OutputConfigurations.Format = requestExport_export_DestinationConfigurations_export_DestinationConfigurations_S3Destination_export_DestinationConfigurations_S3Destination_S3OutputConfigurations_s3OutputConfigurations_Format;
                requestExport_export_DestinationConfigurations_export_DestinationConfigurations_S3Destination_export_DestinationConfigurations_S3Destination_S3OutputConfigurationsIsNull = false;
            }
            Amazon.BCMDataExports.S3OutputType requestExport_export_DestinationConfigurations_export_DestinationConfigurations_S3Destination_export_DestinationConfigurations_S3Destination_S3OutputConfigurations_s3OutputConfigurations_OutputType = null;
            if (cmdletContext.S3OutputConfigurations_OutputType != null)
            {
                requestExport_export_DestinationConfigurations_export_DestinationConfigurations_S3Destination_export_DestinationConfigurations_S3Destination_S3OutputConfigurations_s3OutputConfigurations_OutputType = cmdletContext.S3OutputConfigurations_OutputType;
            }
            if (requestExport_export_DestinationConfigurations_export_DestinationConfigurations_S3Destination_export_DestinationConfigurations_S3Destination_S3OutputConfigurations_s3OutputConfigurations_OutputType != null)
            {
                requestExport_export_DestinationConfigurations_export_DestinationConfigurations_S3Destination_export_DestinationConfigurations_S3Destination_S3OutputConfigurations.OutputType = requestExport_export_DestinationConfigurations_export_DestinationConfigurations_S3Destination_export_DestinationConfigurations_S3Destination_S3OutputConfigurations_s3OutputConfigurations_OutputType;
                requestExport_export_DestinationConfigurations_export_DestinationConfigurations_S3Destination_export_DestinationConfigurations_S3Destination_S3OutputConfigurationsIsNull = false;
            }
            Amazon.BCMDataExports.OverwriteOption requestExport_export_DestinationConfigurations_export_DestinationConfigurations_S3Destination_export_DestinationConfigurations_S3Destination_S3OutputConfigurations_s3OutputConfigurations_Overwrite = null;
            if (cmdletContext.S3OutputConfigurations_Overwrite != null)
            {
                requestExport_export_DestinationConfigurations_export_DestinationConfigurations_S3Destination_export_DestinationConfigurations_S3Destination_S3OutputConfigurations_s3OutputConfigurations_Overwrite = cmdletContext.S3OutputConfigurations_Overwrite;
            }
            if (requestExport_export_DestinationConfigurations_export_DestinationConfigurations_S3Destination_export_DestinationConfigurations_S3Destination_S3OutputConfigurations_s3OutputConfigurations_Overwrite != null)
            {
                requestExport_export_DestinationConfigurations_export_DestinationConfigurations_S3Destination_export_DestinationConfigurations_S3Destination_S3OutputConfigurations.Overwrite = requestExport_export_DestinationConfigurations_export_DestinationConfigurations_S3Destination_export_DestinationConfigurations_S3Destination_S3OutputConfigurations_s3OutputConfigurations_Overwrite;
                requestExport_export_DestinationConfigurations_export_DestinationConfigurations_S3Destination_export_DestinationConfigurations_S3Destination_S3OutputConfigurationsIsNull = false;
            }
             // determine if requestExport_export_DestinationConfigurations_export_DestinationConfigurations_S3Destination_export_DestinationConfigurations_S3Destination_S3OutputConfigurations should be set to null
            if (requestExport_export_DestinationConfigurations_export_DestinationConfigurations_S3Destination_export_DestinationConfigurations_S3Destination_S3OutputConfigurationsIsNull)
            {
                requestExport_export_DestinationConfigurations_export_DestinationConfigurations_S3Destination_export_DestinationConfigurations_S3Destination_S3OutputConfigurations = null;
            }
            if (requestExport_export_DestinationConfigurations_export_DestinationConfigurations_S3Destination_export_DestinationConfigurations_S3Destination_S3OutputConfigurations != null)
            {
                requestExport_export_DestinationConfigurations_export_DestinationConfigurations_S3Destination.S3OutputConfigurations = requestExport_export_DestinationConfigurations_export_DestinationConfigurations_S3Destination_export_DestinationConfigurations_S3Destination_S3OutputConfigurations;
                requestExport_export_DestinationConfigurations_export_DestinationConfigurations_S3DestinationIsNull = false;
            }
             // determine if requestExport_export_DestinationConfigurations_export_DestinationConfigurations_S3Destination should be set to null
            if (requestExport_export_DestinationConfigurations_export_DestinationConfigurations_S3DestinationIsNull)
            {
                requestExport_export_DestinationConfigurations_export_DestinationConfigurations_S3Destination = null;
            }
            if (requestExport_export_DestinationConfigurations_export_DestinationConfigurations_S3Destination != null)
            {
                requestExport_export_DestinationConfigurations.S3Destination = requestExport_export_DestinationConfigurations_export_DestinationConfigurations_S3Destination;
                requestExport_export_DestinationConfigurationsIsNull = false;
            }
             // determine if requestExport_export_DestinationConfigurations should be set to null
            if (requestExport_export_DestinationConfigurationsIsNull)
            {
                requestExport_export_DestinationConfigurations = null;
            }
            if (requestExport_export_DestinationConfigurations != null)
            {
                request.Export.DestinationConfigurations = requestExport_export_DestinationConfigurations;
                requestExportIsNull = false;
            }
            Amazon.BCMDataExports.Model.RefreshCadence requestExport_export_RefreshCadence = null;
            
             // populate RefreshCadence
            var requestExport_export_RefreshCadenceIsNull = true;
            requestExport_export_RefreshCadence = new Amazon.BCMDataExports.Model.RefreshCadence();
            Amazon.BCMDataExports.FrequencyOption requestExport_export_RefreshCadence_refreshCadence_Frequency = null;
            if (cmdletContext.RefreshCadence_Frequency != null)
            {
                requestExport_export_RefreshCadence_refreshCadence_Frequency = cmdletContext.RefreshCadence_Frequency;
            }
            if (requestExport_export_RefreshCadence_refreshCadence_Frequency != null)
            {
                requestExport_export_RefreshCadence.Frequency = requestExport_export_RefreshCadence_refreshCadence_Frequency;
                requestExport_export_RefreshCadenceIsNull = false;
            }
             // determine if requestExport_export_RefreshCadence should be set to null
            if (requestExport_export_RefreshCadenceIsNull)
            {
                requestExport_export_RefreshCadence = null;
            }
            if (requestExport_export_RefreshCadence != null)
            {
                request.Export.RefreshCadence = requestExport_export_RefreshCadence;
                requestExportIsNull = false;
            }
            Amazon.BCMDataExports.Model.DataQuery requestExport_export_DataQuery = null;
            
             // populate DataQuery
            var requestExport_export_DataQueryIsNull = true;
            requestExport_export_DataQuery = new Amazon.BCMDataExports.Model.DataQuery();
            System.String requestExport_export_DataQuery_dataQuery_QueryStatement = null;
            if (cmdletContext.DataQuery_QueryStatement != null)
            {
                requestExport_export_DataQuery_dataQuery_QueryStatement = cmdletContext.DataQuery_QueryStatement;
            }
            if (requestExport_export_DataQuery_dataQuery_QueryStatement != null)
            {
                requestExport_export_DataQuery.QueryStatement = requestExport_export_DataQuery_dataQuery_QueryStatement;
                requestExport_export_DataQueryIsNull = false;
            }
            Dictionary<System.String, Dictionary<System.String, System.String>> requestExport_export_DataQuery_dataQuery_TableConfiguration = null;
            if (cmdletContext.DataQuery_TableConfiguration != null)
            {
                requestExport_export_DataQuery_dataQuery_TableConfiguration = cmdletContext.DataQuery_TableConfiguration;
            }
            if (requestExport_export_DataQuery_dataQuery_TableConfiguration != null)
            {
                requestExport_export_DataQuery.TableConfigurations = requestExport_export_DataQuery_dataQuery_TableConfiguration;
                requestExport_export_DataQueryIsNull = false;
            }
             // determine if requestExport_export_DataQuery should be set to null
            if (requestExport_export_DataQueryIsNull)
            {
                requestExport_export_DataQuery = null;
            }
            if (requestExport_export_DataQuery != null)
            {
                request.Export.DataQuery = requestExport_export_DataQuery;
                requestExportIsNull = false;
            }
             // determine if request.Export should be set to null
            if (requestExportIsNull)
            {
                request.Export = null;
            }
            if (cmdletContext.ExportArn != null)
            {
                request.ExportArn = cmdletContext.ExportArn;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(_CurrentCredentials, _RegionEndpoint);
            try
            {
                var response = CallAWSServiceOperation(client, request);
                object pipelineOutput = null;
                pipelineOutput = cmdletContext.Select(response, this);
                output = new CmdletOutput
                {
                    PipelineOutput = pipelineOutput,
                    ServiceResponse = response
                };
            }
            catch (Exception e)
            {
                output = new CmdletOutput { ErrorResponse = e };
            }
            
            return output;
        }
        
        public ExecutorContext CreateContext()
        {
            return new CmdletContext();
        }
        
        #endregion
        
        #region AWS Service Operation Call
        
        private Amazon.BCMDataExports.Model.UpdateExportResponse CallAWSServiceOperation(IAmazonBCMDataExports client, Amazon.BCMDataExports.Model.UpdateExportRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWSBillingAndCostManagementDataExports", "UpdateExport");
            try
            {
                #if DESKTOP
                return client.UpdateExport(request);
                #elif CORECLR
                return client.UpdateExportAsync(request).GetAwaiter().GetResult();
                #else
                        #error "Unknown build edition"
                #endif
            }
            catch (AmazonServiceException exc)
            {
                var webException = exc.InnerException as System.Net.WebException;
                if (webException != null)
                {
                    throw new Exception(Utils.Common.FormatNameResolutionFailureMessage(client.Config, webException.Message), webException);
                }
                throw;
            }
        }
        
        #endregion
        
        internal partial class CmdletContext : ExecutorContext
        {
            public System.String DataQuery_QueryStatement { get; set; }
            public Dictionary<System.String, Dictionary<System.String, System.String>> DataQuery_TableConfiguration { get; set; }
            public System.String Export_Description { get; set; }
            public System.String S3Destination_S3Bucket { get; set; }
            public Amazon.BCMDataExports.CompressionOption S3OutputConfigurations_Compression { get; set; }
            public Amazon.BCMDataExports.FormatOption S3OutputConfigurations_Format { get; set; }
            public Amazon.BCMDataExports.S3OutputType S3OutputConfigurations_OutputType { get; set; }
            public Amazon.BCMDataExports.OverwriteOption S3OutputConfigurations_Overwrite { get; set; }
            public System.String S3Destination_S3Prefix { get; set; }
            public System.String S3Destination_S3Region { get; set; }
            public System.String Export_ExportArn { get; set; }
            public System.String Export_Name { get; set; }
            public Amazon.BCMDataExports.FrequencyOption RefreshCadence_Frequency { get; set; }
            public System.String ExportArn { get; set; }
            public System.Func<Amazon.BCMDataExports.Model.UpdateExportResponse, UpdateBCMDEExportCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.ExportArn;
        }
        
    }
}
