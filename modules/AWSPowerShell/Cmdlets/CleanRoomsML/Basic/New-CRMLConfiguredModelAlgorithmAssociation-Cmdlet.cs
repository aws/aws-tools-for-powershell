/*******************************************************************************
 *  Copyright Amazon.com, Inc. or its affiliates. All Rights Reserved.
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
using Amazon.CleanRoomsML;
using Amazon.CleanRoomsML.Model;

namespace Amazon.PowerShell.Cmdlets.CRML
{
    /// <summary>
    /// Associates a configured model algorithm to a collaboration for use by any member of
    /// the collaboration.
    /// </summary>
    [Cmdlet("New", "CRMLConfiguredModelAlgorithmAssociation", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the CleanRoomsML CreateConfiguredModelAlgorithmAssociation API operation.", Operation = new[] {"CreateConfiguredModelAlgorithmAssociation"}, SelectReturnType = typeof(Amazon.CleanRoomsML.Model.CreateConfiguredModelAlgorithmAssociationResponse))]
    [AWSCmdletOutput("System.String or Amazon.CleanRoomsML.Model.CreateConfiguredModelAlgorithmAssociationResponse",
        "This cmdlet returns a System.String object.",
        "The service call response (type Amazon.CleanRoomsML.Model.CreateConfiguredModelAlgorithmAssociationResponse) can be returned by specifying '-Select *'."
    )]
    public partial class NewCRMLConfiguredModelAlgorithmAssociationCmdlet : AmazonCleanRoomsMLClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter ConfiguredModelAlgorithmArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the configured model algorithm that you want to
        /// associate.</para>
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
        public System.String ConfiguredModelAlgorithmArn { get; set; }
        #endregion
        
        #region Parameter TrainedModelInferenceJobs_ContainerLog
        /// <summary>
        /// <para>
        /// <para>The logs container for the trained model inference job.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("PrivacyConfiguration_Policies_TrainedModelInferenceJobs_ContainerLogs")]
        public Amazon.CleanRoomsML.Model.LogsConfigurationPolicy[] TrainedModelInferenceJobs_ContainerLog { get; set; }
        #endregion
        
        #region Parameter TrainedModels_ContainerLog
        /// <summary>
        /// <para>
        /// <para>The container for the logs of the trained model.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("PrivacyConfiguration_Policies_TrainedModels_ContainerLogs")]
        public Amazon.CleanRoomsML.Model.LogsConfigurationPolicy[] TrainedModels_ContainerLog { get; set; }
        #endregion
        
        #region Parameter Description
        /// <summary>
        /// <para>
        /// <para>The description of the configured model algorithm association.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Description { get; set; }
        #endregion
        
        #region Parameter TrainedModelExports_FilesToExport
        /// <summary>
        /// <para>
        /// <para>The files that are exported during the trained model export job.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("PrivacyConfiguration_Policies_TrainedModelExports_FilesToExport")]
        public System.String[] TrainedModelExports_FilesToExport { get; set; }
        #endregion
        
        #region Parameter MembershipIdentifier
        /// <summary>
        /// <para>
        /// <para>The membership ID of the member who is associating this configured model algorithm.</para>
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
        public System.String MembershipIdentifier { get; set; }
        #endregion
        
        #region Parameter Name
        /// <summary>
        /// <para>
        /// <para>The name of the configured model algorithm association.</para>
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
        public System.String Name { get; set; }
        #endregion
        
        #region Parameter ContainerMetrics_NoiseLevel
        /// <summary>
        /// <para>
        /// <para>The noise level for the generated metrics.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("PrivacyConfiguration_Policies_TrainedModels_ContainerMetrics_NoiseLevel")]
        [AWSConstantClassSource("Amazon.CleanRoomsML.NoiseLevelType")]
        public Amazon.CleanRoomsML.NoiseLevelType ContainerMetrics_NoiseLevel { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>The optional metadata that you apply to the resource to help you categorize and organize
        /// them. Each tag consists of a key and an optional value, both of which you define.</para><para>The following basic restrictions apply to tags:</para><ul><li><para>Maximum number of tags per resource - 50.</para></li><li><para>For each resource, each tag key must be unique, and each tag key can have only one
        /// value.</para></li><li><para>Maximum key length - 128 Unicode characters in UTF-8.</para></li><li><para>Maximum value length - 256 Unicode characters in UTF-8.</para></li><li><para>If your tagging schema is used across multiple services and resources, remember that
        /// other services may have restrictions on allowed characters. Generally allowed characters
        /// are: letters, numbers, and spaces representable in UTF-8, and the following characters:
        /// + - = . _ : / @.</para></li><li><para>Tag keys and values are case sensitive.</para></li><li><para>Do not use aws:, AWS:, or any upper or lowercase combination of such as a prefix for
        /// keys as it is reserved for AWS use. You cannot edit or delete tag keys with this prefix.
        /// Values can have this prefix. If a tag value has aws as its prefix but the key does
        /// not, then Clean Rooms ML considers it to be a user tag and will count against the
        /// limit of 50 tags. Tags with only the key prefix of aws do not count against your tags
        /// per resource limit.</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public System.Collections.Hashtable Tag { get; set; }
        #endregion
        
        #region Parameter MaxSize_Unit
        /// <summary>
        /// <para>
        /// <para>The unit of measurement for the data size.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("PrivacyConfiguration_Policies_TrainedModelExports_MaxSize_Unit")]
        [AWSConstantClassSource("Amazon.CleanRoomsML.TrainedModelExportsMaxSizeUnitType")]
        public Amazon.CleanRoomsML.TrainedModelExportsMaxSizeUnitType MaxSize_Unit { get; set; }
        #endregion
        
        #region Parameter MaxOutputSize_Unit
        /// <summary>
        /// <para>
        /// <para>The measurement unit to use.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("PrivacyConfiguration_Policies_TrainedModelInferenceJobs_MaxOutputSize_Unit")]
        [AWSConstantClassSource("Amazon.CleanRoomsML.TrainedModelInferenceMaxOutputSizeUnitType")]
        public Amazon.CleanRoomsML.TrainedModelInferenceMaxOutputSizeUnitType MaxOutputSize_Unit { get; set; }
        #endregion
        
        #region Parameter MaxSize_Value
        /// <summary>
        /// <para>
        /// <para>The maximum size of the dataset to export.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("PrivacyConfiguration_Policies_TrainedModelExports_MaxSize_Value")]
        public System.Double? MaxSize_Value { get; set; }
        #endregion
        
        #region Parameter MaxOutputSize_Value
        /// <summary>
        /// <para>
        /// <para>The maximum output size value.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("PrivacyConfiguration_Policies_TrainedModelInferenceJobs_MaxOutputSize_Value")]
        public System.Double? MaxOutputSize_Value { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'ConfiguredModelAlgorithmAssociationArn'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.CleanRoomsML.Model.CreateConfiguredModelAlgorithmAssociationResponse).
        /// Specifying the name of a property of type Amazon.CleanRoomsML.Model.CreateConfiguredModelAlgorithmAssociationResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "ConfiguredModelAlgorithmAssociationArn";
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
            
            var resourceIdentifiersText = string.Empty;
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-CRMLConfiguredModelAlgorithmAssociation (CreateConfiguredModelAlgorithmAssociation)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.CleanRoomsML.Model.CreateConfiguredModelAlgorithmAssociationResponse, NewCRMLConfiguredModelAlgorithmAssociationCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.ConfiguredModelAlgorithmArn = this.ConfiguredModelAlgorithmArn;
            #if MODULAR
            if (this.ConfiguredModelAlgorithmArn == null && ParameterWasBound(nameof(this.ConfiguredModelAlgorithmArn)))
            {
                WriteWarning("You are passing $null as a value for parameter ConfiguredModelAlgorithmArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Description = this.Description;
            context.MembershipIdentifier = this.MembershipIdentifier;
            #if MODULAR
            if (this.MembershipIdentifier == null && ParameterWasBound(nameof(this.MembershipIdentifier)))
            {
                WriteWarning("You are passing $null as a value for parameter MembershipIdentifier which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Name = this.Name;
            #if MODULAR
            if (this.Name == null && ParameterWasBound(nameof(this.Name)))
            {
                WriteWarning("You are passing $null as a value for parameter Name which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.TrainedModelExports_FilesToExport != null)
            {
                context.TrainedModelExports_FilesToExport = new List<System.String>(this.TrainedModelExports_FilesToExport);
            }
            context.MaxSize_Unit = this.MaxSize_Unit;
            context.MaxSize_Value = this.MaxSize_Value;
            if (this.TrainedModelInferenceJobs_ContainerLog != null)
            {
                context.TrainedModelInferenceJobs_ContainerLog = new List<Amazon.CleanRoomsML.Model.LogsConfigurationPolicy>(this.TrainedModelInferenceJobs_ContainerLog);
            }
            context.MaxOutputSize_Unit = this.MaxOutputSize_Unit;
            context.MaxOutputSize_Value = this.MaxOutputSize_Value;
            if (this.TrainedModels_ContainerLog != null)
            {
                context.TrainedModels_ContainerLog = new List<Amazon.CleanRoomsML.Model.LogsConfigurationPolicy>(this.TrainedModels_ContainerLog);
            }
            context.ContainerMetrics_NoiseLevel = this.ContainerMetrics_NoiseLevel;
            if (this.Tag != null)
            {
                context.Tag = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.Tag.Keys)
                {
                    context.Tag.Add((String)hashKey, (System.String)(this.Tag[hashKey]));
                }
            }
            
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
            var request = new Amazon.CleanRoomsML.Model.CreateConfiguredModelAlgorithmAssociationRequest();
            
            if (cmdletContext.ConfiguredModelAlgorithmArn != null)
            {
                request.ConfiguredModelAlgorithmArn = cmdletContext.ConfiguredModelAlgorithmArn;
            }
            if (cmdletContext.Description != null)
            {
                request.Description = cmdletContext.Description;
            }
            if (cmdletContext.MembershipIdentifier != null)
            {
                request.MembershipIdentifier = cmdletContext.MembershipIdentifier;
            }
            if (cmdletContext.Name != null)
            {
                request.Name = cmdletContext.Name;
            }
            
             // populate PrivacyConfiguration
            var requestPrivacyConfigurationIsNull = true;
            request.PrivacyConfiguration = new Amazon.CleanRoomsML.Model.PrivacyConfiguration();
            Amazon.CleanRoomsML.Model.PrivacyConfigurationPolicies requestPrivacyConfiguration_privacyConfiguration_Policies = null;
            
             // populate Policies
            var requestPrivacyConfiguration_privacyConfiguration_PoliciesIsNull = true;
            requestPrivacyConfiguration_privacyConfiguration_Policies = new Amazon.CleanRoomsML.Model.PrivacyConfigurationPolicies();
            Amazon.CleanRoomsML.Model.TrainedModelExportsConfigurationPolicy requestPrivacyConfiguration_privacyConfiguration_Policies_privacyConfiguration_Policies_TrainedModelExports = null;
            
             // populate TrainedModelExports
            var requestPrivacyConfiguration_privacyConfiguration_Policies_privacyConfiguration_Policies_TrainedModelExportsIsNull = true;
            requestPrivacyConfiguration_privacyConfiguration_Policies_privacyConfiguration_Policies_TrainedModelExports = new Amazon.CleanRoomsML.Model.TrainedModelExportsConfigurationPolicy();
            List<System.String> requestPrivacyConfiguration_privacyConfiguration_Policies_privacyConfiguration_Policies_TrainedModelExports_trainedModelExports_FilesToExport = null;
            if (cmdletContext.TrainedModelExports_FilesToExport != null)
            {
                requestPrivacyConfiguration_privacyConfiguration_Policies_privacyConfiguration_Policies_TrainedModelExports_trainedModelExports_FilesToExport = cmdletContext.TrainedModelExports_FilesToExport;
            }
            if (requestPrivacyConfiguration_privacyConfiguration_Policies_privacyConfiguration_Policies_TrainedModelExports_trainedModelExports_FilesToExport != null)
            {
                requestPrivacyConfiguration_privacyConfiguration_Policies_privacyConfiguration_Policies_TrainedModelExports.FilesToExport = requestPrivacyConfiguration_privacyConfiguration_Policies_privacyConfiguration_Policies_TrainedModelExports_trainedModelExports_FilesToExport;
                requestPrivacyConfiguration_privacyConfiguration_Policies_privacyConfiguration_Policies_TrainedModelExportsIsNull = false;
            }
            Amazon.CleanRoomsML.Model.TrainedModelExportsMaxSize requestPrivacyConfiguration_privacyConfiguration_Policies_privacyConfiguration_Policies_TrainedModelExports_privacyConfiguration_Policies_TrainedModelExports_MaxSize = null;
            
             // populate MaxSize
            var requestPrivacyConfiguration_privacyConfiguration_Policies_privacyConfiguration_Policies_TrainedModelExports_privacyConfiguration_Policies_TrainedModelExports_MaxSizeIsNull = true;
            requestPrivacyConfiguration_privacyConfiguration_Policies_privacyConfiguration_Policies_TrainedModelExports_privacyConfiguration_Policies_TrainedModelExports_MaxSize = new Amazon.CleanRoomsML.Model.TrainedModelExportsMaxSize();
            Amazon.CleanRoomsML.TrainedModelExportsMaxSizeUnitType requestPrivacyConfiguration_privacyConfiguration_Policies_privacyConfiguration_Policies_TrainedModelExports_privacyConfiguration_Policies_TrainedModelExports_MaxSize_maxSize_Unit = null;
            if (cmdletContext.MaxSize_Unit != null)
            {
                requestPrivacyConfiguration_privacyConfiguration_Policies_privacyConfiguration_Policies_TrainedModelExports_privacyConfiguration_Policies_TrainedModelExports_MaxSize_maxSize_Unit = cmdletContext.MaxSize_Unit;
            }
            if (requestPrivacyConfiguration_privacyConfiguration_Policies_privacyConfiguration_Policies_TrainedModelExports_privacyConfiguration_Policies_TrainedModelExports_MaxSize_maxSize_Unit != null)
            {
                requestPrivacyConfiguration_privacyConfiguration_Policies_privacyConfiguration_Policies_TrainedModelExports_privacyConfiguration_Policies_TrainedModelExports_MaxSize.Unit = requestPrivacyConfiguration_privacyConfiguration_Policies_privacyConfiguration_Policies_TrainedModelExports_privacyConfiguration_Policies_TrainedModelExports_MaxSize_maxSize_Unit;
                requestPrivacyConfiguration_privacyConfiguration_Policies_privacyConfiguration_Policies_TrainedModelExports_privacyConfiguration_Policies_TrainedModelExports_MaxSizeIsNull = false;
            }
            System.Double? requestPrivacyConfiguration_privacyConfiguration_Policies_privacyConfiguration_Policies_TrainedModelExports_privacyConfiguration_Policies_TrainedModelExports_MaxSize_maxSize_Value = null;
            if (cmdletContext.MaxSize_Value != null)
            {
                requestPrivacyConfiguration_privacyConfiguration_Policies_privacyConfiguration_Policies_TrainedModelExports_privacyConfiguration_Policies_TrainedModelExports_MaxSize_maxSize_Value = cmdletContext.MaxSize_Value.Value;
            }
            if (requestPrivacyConfiguration_privacyConfiguration_Policies_privacyConfiguration_Policies_TrainedModelExports_privacyConfiguration_Policies_TrainedModelExports_MaxSize_maxSize_Value != null)
            {
                requestPrivacyConfiguration_privacyConfiguration_Policies_privacyConfiguration_Policies_TrainedModelExports_privacyConfiguration_Policies_TrainedModelExports_MaxSize.Value = requestPrivacyConfiguration_privacyConfiguration_Policies_privacyConfiguration_Policies_TrainedModelExports_privacyConfiguration_Policies_TrainedModelExports_MaxSize_maxSize_Value.Value;
                requestPrivacyConfiguration_privacyConfiguration_Policies_privacyConfiguration_Policies_TrainedModelExports_privacyConfiguration_Policies_TrainedModelExports_MaxSizeIsNull = false;
            }
             // determine if requestPrivacyConfiguration_privacyConfiguration_Policies_privacyConfiguration_Policies_TrainedModelExports_privacyConfiguration_Policies_TrainedModelExports_MaxSize should be set to null
            if (requestPrivacyConfiguration_privacyConfiguration_Policies_privacyConfiguration_Policies_TrainedModelExports_privacyConfiguration_Policies_TrainedModelExports_MaxSizeIsNull)
            {
                requestPrivacyConfiguration_privacyConfiguration_Policies_privacyConfiguration_Policies_TrainedModelExports_privacyConfiguration_Policies_TrainedModelExports_MaxSize = null;
            }
            if (requestPrivacyConfiguration_privacyConfiguration_Policies_privacyConfiguration_Policies_TrainedModelExports_privacyConfiguration_Policies_TrainedModelExports_MaxSize != null)
            {
                requestPrivacyConfiguration_privacyConfiguration_Policies_privacyConfiguration_Policies_TrainedModelExports.MaxSize = requestPrivacyConfiguration_privacyConfiguration_Policies_privacyConfiguration_Policies_TrainedModelExports_privacyConfiguration_Policies_TrainedModelExports_MaxSize;
                requestPrivacyConfiguration_privacyConfiguration_Policies_privacyConfiguration_Policies_TrainedModelExportsIsNull = false;
            }
             // determine if requestPrivacyConfiguration_privacyConfiguration_Policies_privacyConfiguration_Policies_TrainedModelExports should be set to null
            if (requestPrivacyConfiguration_privacyConfiguration_Policies_privacyConfiguration_Policies_TrainedModelExportsIsNull)
            {
                requestPrivacyConfiguration_privacyConfiguration_Policies_privacyConfiguration_Policies_TrainedModelExports = null;
            }
            if (requestPrivacyConfiguration_privacyConfiguration_Policies_privacyConfiguration_Policies_TrainedModelExports != null)
            {
                requestPrivacyConfiguration_privacyConfiguration_Policies.TrainedModelExports = requestPrivacyConfiguration_privacyConfiguration_Policies_privacyConfiguration_Policies_TrainedModelExports;
                requestPrivacyConfiguration_privacyConfiguration_PoliciesIsNull = false;
            }
            Amazon.CleanRoomsML.Model.TrainedModelInferenceJobsConfigurationPolicy requestPrivacyConfiguration_privacyConfiguration_Policies_privacyConfiguration_Policies_TrainedModelInferenceJobs = null;
            
             // populate TrainedModelInferenceJobs
            var requestPrivacyConfiguration_privacyConfiguration_Policies_privacyConfiguration_Policies_TrainedModelInferenceJobsIsNull = true;
            requestPrivacyConfiguration_privacyConfiguration_Policies_privacyConfiguration_Policies_TrainedModelInferenceJobs = new Amazon.CleanRoomsML.Model.TrainedModelInferenceJobsConfigurationPolicy();
            List<Amazon.CleanRoomsML.Model.LogsConfigurationPolicy> requestPrivacyConfiguration_privacyConfiguration_Policies_privacyConfiguration_Policies_TrainedModelInferenceJobs_trainedModelInferenceJobs_ContainerLog = null;
            if (cmdletContext.TrainedModelInferenceJobs_ContainerLog != null)
            {
                requestPrivacyConfiguration_privacyConfiguration_Policies_privacyConfiguration_Policies_TrainedModelInferenceJobs_trainedModelInferenceJobs_ContainerLog = cmdletContext.TrainedModelInferenceJobs_ContainerLog;
            }
            if (requestPrivacyConfiguration_privacyConfiguration_Policies_privacyConfiguration_Policies_TrainedModelInferenceJobs_trainedModelInferenceJobs_ContainerLog != null)
            {
                requestPrivacyConfiguration_privacyConfiguration_Policies_privacyConfiguration_Policies_TrainedModelInferenceJobs.ContainerLogs = requestPrivacyConfiguration_privacyConfiguration_Policies_privacyConfiguration_Policies_TrainedModelInferenceJobs_trainedModelInferenceJobs_ContainerLog;
                requestPrivacyConfiguration_privacyConfiguration_Policies_privacyConfiguration_Policies_TrainedModelInferenceJobsIsNull = false;
            }
            Amazon.CleanRoomsML.Model.TrainedModelInferenceMaxOutputSize requestPrivacyConfiguration_privacyConfiguration_Policies_privacyConfiguration_Policies_TrainedModelInferenceJobs_privacyConfiguration_Policies_TrainedModelInferenceJobs_MaxOutputSize = null;
            
             // populate MaxOutputSize
            var requestPrivacyConfiguration_privacyConfiguration_Policies_privacyConfiguration_Policies_TrainedModelInferenceJobs_privacyConfiguration_Policies_TrainedModelInferenceJobs_MaxOutputSizeIsNull = true;
            requestPrivacyConfiguration_privacyConfiguration_Policies_privacyConfiguration_Policies_TrainedModelInferenceJobs_privacyConfiguration_Policies_TrainedModelInferenceJobs_MaxOutputSize = new Amazon.CleanRoomsML.Model.TrainedModelInferenceMaxOutputSize();
            Amazon.CleanRoomsML.TrainedModelInferenceMaxOutputSizeUnitType requestPrivacyConfiguration_privacyConfiguration_Policies_privacyConfiguration_Policies_TrainedModelInferenceJobs_privacyConfiguration_Policies_TrainedModelInferenceJobs_MaxOutputSize_maxOutputSize_Unit = null;
            if (cmdletContext.MaxOutputSize_Unit != null)
            {
                requestPrivacyConfiguration_privacyConfiguration_Policies_privacyConfiguration_Policies_TrainedModelInferenceJobs_privacyConfiguration_Policies_TrainedModelInferenceJobs_MaxOutputSize_maxOutputSize_Unit = cmdletContext.MaxOutputSize_Unit;
            }
            if (requestPrivacyConfiguration_privacyConfiguration_Policies_privacyConfiguration_Policies_TrainedModelInferenceJobs_privacyConfiguration_Policies_TrainedModelInferenceJobs_MaxOutputSize_maxOutputSize_Unit != null)
            {
                requestPrivacyConfiguration_privacyConfiguration_Policies_privacyConfiguration_Policies_TrainedModelInferenceJobs_privacyConfiguration_Policies_TrainedModelInferenceJobs_MaxOutputSize.Unit = requestPrivacyConfiguration_privacyConfiguration_Policies_privacyConfiguration_Policies_TrainedModelInferenceJobs_privacyConfiguration_Policies_TrainedModelInferenceJobs_MaxOutputSize_maxOutputSize_Unit;
                requestPrivacyConfiguration_privacyConfiguration_Policies_privacyConfiguration_Policies_TrainedModelInferenceJobs_privacyConfiguration_Policies_TrainedModelInferenceJobs_MaxOutputSizeIsNull = false;
            }
            System.Double? requestPrivacyConfiguration_privacyConfiguration_Policies_privacyConfiguration_Policies_TrainedModelInferenceJobs_privacyConfiguration_Policies_TrainedModelInferenceJobs_MaxOutputSize_maxOutputSize_Value = null;
            if (cmdletContext.MaxOutputSize_Value != null)
            {
                requestPrivacyConfiguration_privacyConfiguration_Policies_privacyConfiguration_Policies_TrainedModelInferenceJobs_privacyConfiguration_Policies_TrainedModelInferenceJobs_MaxOutputSize_maxOutputSize_Value = cmdletContext.MaxOutputSize_Value.Value;
            }
            if (requestPrivacyConfiguration_privacyConfiguration_Policies_privacyConfiguration_Policies_TrainedModelInferenceJobs_privacyConfiguration_Policies_TrainedModelInferenceJobs_MaxOutputSize_maxOutputSize_Value != null)
            {
                requestPrivacyConfiguration_privacyConfiguration_Policies_privacyConfiguration_Policies_TrainedModelInferenceJobs_privacyConfiguration_Policies_TrainedModelInferenceJobs_MaxOutputSize.Value = requestPrivacyConfiguration_privacyConfiguration_Policies_privacyConfiguration_Policies_TrainedModelInferenceJobs_privacyConfiguration_Policies_TrainedModelInferenceJobs_MaxOutputSize_maxOutputSize_Value.Value;
                requestPrivacyConfiguration_privacyConfiguration_Policies_privacyConfiguration_Policies_TrainedModelInferenceJobs_privacyConfiguration_Policies_TrainedModelInferenceJobs_MaxOutputSizeIsNull = false;
            }
             // determine if requestPrivacyConfiguration_privacyConfiguration_Policies_privacyConfiguration_Policies_TrainedModelInferenceJobs_privacyConfiguration_Policies_TrainedModelInferenceJobs_MaxOutputSize should be set to null
            if (requestPrivacyConfiguration_privacyConfiguration_Policies_privacyConfiguration_Policies_TrainedModelInferenceJobs_privacyConfiguration_Policies_TrainedModelInferenceJobs_MaxOutputSizeIsNull)
            {
                requestPrivacyConfiguration_privacyConfiguration_Policies_privacyConfiguration_Policies_TrainedModelInferenceJobs_privacyConfiguration_Policies_TrainedModelInferenceJobs_MaxOutputSize = null;
            }
            if (requestPrivacyConfiguration_privacyConfiguration_Policies_privacyConfiguration_Policies_TrainedModelInferenceJobs_privacyConfiguration_Policies_TrainedModelInferenceJobs_MaxOutputSize != null)
            {
                requestPrivacyConfiguration_privacyConfiguration_Policies_privacyConfiguration_Policies_TrainedModelInferenceJobs.MaxOutputSize = requestPrivacyConfiguration_privacyConfiguration_Policies_privacyConfiguration_Policies_TrainedModelInferenceJobs_privacyConfiguration_Policies_TrainedModelInferenceJobs_MaxOutputSize;
                requestPrivacyConfiguration_privacyConfiguration_Policies_privacyConfiguration_Policies_TrainedModelInferenceJobsIsNull = false;
            }
             // determine if requestPrivacyConfiguration_privacyConfiguration_Policies_privacyConfiguration_Policies_TrainedModelInferenceJobs should be set to null
            if (requestPrivacyConfiguration_privacyConfiguration_Policies_privacyConfiguration_Policies_TrainedModelInferenceJobsIsNull)
            {
                requestPrivacyConfiguration_privacyConfiguration_Policies_privacyConfiguration_Policies_TrainedModelInferenceJobs = null;
            }
            if (requestPrivacyConfiguration_privacyConfiguration_Policies_privacyConfiguration_Policies_TrainedModelInferenceJobs != null)
            {
                requestPrivacyConfiguration_privacyConfiguration_Policies.TrainedModelInferenceJobs = requestPrivacyConfiguration_privacyConfiguration_Policies_privacyConfiguration_Policies_TrainedModelInferenceJobs;
                requestPrivacyConfiguration_privacyConfiguration_PoliciesIsNull = false;
            }
            Amazon.CleanRoomsML.Model.TrainedModelsConfigurationPolicy requestPrivacyConfiguration_privacyConfiguration_Policies_privacyConfiguration_Policies_TrainedModels = null;
            
             // populate TrainedModels
            var requestPrivacyConfiguration_privacyConfiguration_Policies_privacyConfiguration_Policies_TrainedModelsIsNull = true;
            requestPrivacyConfiguration_privacyConfiguration_Policies_privacyConfiguration_Policies_TrainedModels = new Amazon.CleanRoomsML.Model.TrainedModelsConfigurationPolicy();
            List<Amazon.CleanRoomsML.Model.LogsConfigurationPolicy> requestPrivacyConfiguration_privacyConfiguration_Policies_privacyConfiguration_Policies_TrainedModels_trainedModels_ContainerLog = null;
            if (cmdletContext.TrainedModels_ContainerLog != null)
            {
                requestPrivacyConfiguration_privacyConfiguration_Policies_privacyConfiguration_Policies_TrainedModels_trainedModels_ContainerLog = cmdletContext.TrainedModels_ContainerLog;
            }
            if (requestPrivacyConfiguration_privacyConfiguration_Policies_privacyConfiguration_Policies_TrainedModels_trainedModels_ContainerLog != null)
            {
                requestPrivacyConfiguration_privacyConfiguration_Policies_privacyConfiguration_Policies_TrainedModels.ContainerLogs = requestPrivacyConfiguration_privacyConfiguration_Policies_privacyConfiguration_Policies_TrainedModels_trainedModels_ContainerLog;
                requestPrivacyConfiguration_privacyConfiguration_Policies_privacyConfiguration_Policies_TrainedModelsIsNull = false;
            }
            Amazon.CleanRoomsML.Model.MetricsConfigurationPolicy requestPrivacyConfiguration_privacyConfiguration_Policies_privacyConfiguration_Policies_TrainedModels_privacyConfiguration_Policies_TrainedModels_ContainerMetrics = null;
            
             // populate ContainerMetrics
            var requestPrivacyConfiguration_privacyConfiguration_Policies_privacyConfiguration_Policies_TrainedModels_privacyConfiguration_Policies_TrainedModels_ContainerMetricsIsNull = true;
            requestPrivacyConfiguration_privacyConfiguration_Policies_privacyConfiguration_Policies_TrainedModels_privacyConfiguration_Policies_TrainedModels_ContainerMetrics = new Amazon.CleanRoomsML.Model.MetricsConfigurationPolicy();
            Amazon.CleanRoomsML.NoiseLevelType requestPrivacyConfiguration_privacyConfiguration_Policies_privacyConfiguration_Policies_TrainedModels_privacyConfiguration_Policies_TrainedModels_ContainerMetrics_containerMetrics_NoiseLevel = null;
            if (cmdletContext.ContainerMetrics_NoiseLevel != null)
            {
                requestPrivacyConfiguration_privacyConfiguration_Policies_privacyConfiguration_Policies_TrainedModels_privacyConfiguration_Policies_TrainedModels_ContainerMetrics_containerMetrics_NoiseLevel = cmdletContext.ContainerMetrics_NoiseLevel;
            }
            if (requestPrivacyConfiguration_privacyConfiguration_Policies_privacyConfiguration_Policies_TrainedModels_privacyConfiguration_Policies_TrainedModels_ContainerMetrics_containerMetrics_NoiseLevel != null)
            {
                requestPrivacyConfiguration_privacyConfiguration_Policies_privacyConfiguration_Policies_TrainedModels_privacyConfiguration_Policies_TrainedModels_ContainerMetrics.NoiseLevel = requestPrivacyConfiguration_privacyConfiguration_Policies_privacyConfiguration_Policies_TrainedModels_privacyConfiguration_Policies_TrainedModels_ContainerMetrics_containerMetrics_NoiseLevel;
                requestPrivacyConfiguration_privacyConfiguration_Policies_privacyConfiguration_Policies_TrainedModels_privacyConfiguration_Policies_TrainedModels_ContainerMetricsIsNull = false;
            }
             // determine if requestPrivacyConfiguration_privacyConfiguration_Policies_privacyConfiguration_Policies_TrainedModels_privacyConfiguration_Policies_TrainedModels_ContainerMetrics should be set to null
            if (requestPrivacyConfiguration_privacyConfiguration_Policies_privacyConfiguration_Policies_TrainedModels_privacyConfiguration_Policies_TrainedModels_ContainerMetricsIsNull)
            {
                requestPrivacyConfiguration_privacyConfiguration_Policies_privacyConfiguration_Policies_TrainedModels_privacyConfiguration_Policies_TrainedModels_ContainerMetrics = null;
            }
            if (requestPrivacyConfiguration_privacyConfiguration_Policies_privacyConfiguration_Policies_TrainedModels_privacyConfiguration_Policies_TrainedModels_ContainerMetrics != null)
            {
                requestPrivacyConfiguration_privacyConfiguration_Policies_privacyConfiguration_Policies_TrainedModels.ContainerMetrics = requestPrivacyConfiguration_privacyConfiguration_Policies_privacyConfiguration_Policies_TrainedModels_privacyConfiguration_Policies_TrainedModels_ContainerMetrics;
                requestPrivacyConfiguration_privacyConfiguration_Policies_privacyConfiguration_Policies_TrainedModelsIsNull = false;
            }
             // determine if requestPrivacyConfiguration_privacyConfiguration_Policies_privacyConfiguration_Policies_TrainedModels should be set to null
            if (requestPrivacyConfiguration_privacyConfiguration_Policies_privacyConfiguration_Policies_TrainedModelsIsNull)
            {
                requestPrivacyConfiguration_privacyConfiguration_Policies_privacyConfiguration_Policies_TrainedModels = null;
            }
            if (requestPrivacyConfiguration_privacyConfiguration_Policies_privacyConfiguration_Policies_TrainedModels != null)
            {
                requestPrivacyConfiguration_privacyConfiguration_Policies.TrainedModels = requestPrivacyConfiguration_privacyConfiguration_Policies_privacyConfiguration_Policies_TrainedModels;
                requestPrivacyConfiguration_privacyConfiguration_PoliciesIsNull = false;
            }
             // determine if requestPrivacyConfiguration_privacyConfiguration_Policies should be set to null
            if (requestPrivacyConfiguration_privacyConfiguration_PoliciesIsNull)
            {
                requestPrivacyConfiguration_privacyConfiguration_Policies = null;
            }
            if (requestPrivacyConfiguration_privacyConfiguration_Policies != null)
            {
                request.PrivacyConfiguration.Policies = requestPrivacyConfiguration_privacyConfiguration_Policies;
                requestPrivacyConfigurationIsNull = false;
            }
             // determine if request.PrivacyConfiguration should be set to null
            if (requestPrivacyConfigurationIsNull)
            {
                request.PrivacyConfiguration = null;
            }
            if (cmdletContext.Tag != null)
            {
                request.Tags = cmdletContext.Tag;
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
        
        private Amazon.CleanRoomsML.Model.CreateConfiguredModelAlgorithmAssociationResponse CallAWSServiceOperation(IAmazonCleanRoomsML client, Amazon.CleanRoomsML.Model.CreateConfiguredModelAlgorithmAssociationRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "CleanRoomsML", "CreateConfiguredModelAlgorithmAssociation");
            try
            {
                #if DESKTOP
                return client.CreateConfiguredModelAlgorithmAssociation(request);
                #elif CORECLR
                return client.CreateConfiguredModelAlgorithmAssociationAsync(request).GetAwaiter().GetResult();
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
            public System.String ConfiguredModelAlgorithmArn { get; set; }
            public System.String Description { get; set; }
            public System.String MembershipIdentifier { get; set; }
            public System.String Name { get; set; }
            public List<System.String> TrainedModelExports_FilesToExport { get; set; }
            public Amazon.CleanRoomsML.TrainedModelExportsMaxSizeUnitType MaxSize_Unit { get; set; }
            public System.Double? MaxSize_Value { get; set; }
            public List<Amazon.CleanRoomsML.Model.LogsConfigurationPolicy> TrainedModelInferenceJobs_ContainerLog { get; set; }
            public Amazon.CleanRoomsML.TrainedModelInferenceMaxOutputSizeUnitType MaxOutputSize_Unit { get; set; }
            public System.Double? MaxOutputSize_Value { get; set; }
            public List<Amazon.CleanRoomsML.Model.LogsConfigurationPolicy> TrainedModels_ContainerLog { get; set; }
            public Amazon.CleanRoomsML.NoiseLevelType ContainerMetrics_NoiseLevel { get; set; }
            public Dictionary<System.String, System.String> Tag { get; set; }
            public System.Func<Amazon.CleanRoomsML.Model.CreateConfiguredModelAlgorithmAssociationResponse, NewCRMLConfiguredModelAlgorithmAssociationCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.ConfiguredModelAlgorithmAssociationArn;
        }
        
    }
}
