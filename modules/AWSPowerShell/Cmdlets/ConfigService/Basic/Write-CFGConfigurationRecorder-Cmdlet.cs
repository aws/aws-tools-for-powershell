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
using Amazon.ConfigService;
using Amazon.ConfigService.Model;

namespace Amazon.PowerShell.Cmdlets.CFG
{
    /// <summary>
    /// Creates a new configuration recorder to record configuration changes for specified
    /// resource types.
    /// 
    ///  
    /// <para>
    /// You can also use this action to change the <code>roleARN</code> or the <code>recordingGroup</code>
    /// of an existing recorder. For more information, see <a href="https://docs.aws.amazon.com/config/latest/developerguide/stop-start-recorder.html"><b>Managing the Configuration Recorder</b></a> in the <i>Config Developer Guide</i>.
    /// </para><note><para>
    /// You can specify only one configuration recorder for each Amazon Web Services Region
    /// for each account.
    /// </para><para>
    /// If the configuration recorder does not have the <code>recordingGroup</code> field
    /// specified, the default is to record all supported resource types.
    /// </para></note>
    /// </summary>
    [Cmdlet("Write", "CFGConfigurationRecorder", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("None")]
    [AWSCmdlet("Calls the AWS Config PutConfigurationRecorder API operation.", Operation = new[] {"PutConfigurationRecorder"}, SelectReturnType = typeof(Amazon.ConfigService.Model.PutConfigurationRecorderResponse))]
    [AWSCmdletOutput("None or Amazon.ConfigService.Model.PutConfigurationRecorderResponse",
        "This cmdlet does not generate any output." +
        "The service response (type Amazon.ConfigService.Model.PutConfigurationRecorderResponse) can be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class WriteCFGConfigurationRecorderCmdlet : AmazonConfigServiceClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter RecordingGroup_AllSupported
        /// <summary>
        /// <para>
        /// <para>Specifies whether Config records configuration changes for all supported regional
        /// resource types.</para><para>If you set this field to <code>true</code>, when Config adds support for a new type
        /// of regional resource, Config starts recording resources of that type automatically.</para><para>If you set this field to <code>true</code>, you cannot enumerate specific resource
        /// types to record in the <code>resourceTypes</code> field of <a href="https://docs.aws.amazon.com/config/latest/APIReference/API_RecordingGroup.html">RecordingGroup</a>,
        /// or to exclude in the <code>resourceTypes</code> field of <a href="https://docs.aws.amazon.com/config/latest/APIReference/API_ExclusionByResourceTypes.html">ExclusionByResourceTypes</a>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ConfigurationRecorder_RecordingGroup_AllSupported")]
        public System.Boolean? RecordingGroup_AllSupported { get; set; }
        #endregion
        
        #region Parameter RecordingGroup_IncludeGlobalResourceType
        /// <summary>
        /// <para>
        /// <para>Specifies whether Config records configuration changes for all supported global resources.</para><para>Before you set this field to <code>true</code>, set the <code>allSupported</code>
        /// field of <a href="https://docs.aws.amazon.com/config/latest/APIReference/API_RecordingGroup.html">RecordingGroup</a>
        /// to <code>true</code>. Optionally, you can set the <code>useOnly</code> field of <a href="https://docs.aws.amazon.com/config/latest/APIReference/API_RecordingStrategy.html">RecordingStrategy</a>
        /// to <code>ALL_SUPPORTED_RESOURCE_TYPES</code>.</para><para>If you set this field to <code>true</code>, when Config adds support for a new type
        /// of global resource in the Region where you set up the configuration recorder, Config
        /// starts recording resources of that type automatically.</para><note><para>If you set this field to <code>false</code> but list global resource types in the
        /// <code>resourceTypes</code> field of <a href="https://docs.aws.amazon.com/config/latest/APIReference/API_RecordingGroup.html">RecordingGroup</a>,
        /// Config will still record configuration changes for those specified resource types
        /// <i>regardless</i> of if you set the <code>includeGlobalResourceTypes</code> field
        /// to false.</para><para>If you do not want to record configuration changes to global resource types, make
        /// sure to not list them in the <code>resourceTypes</code> field in addition to setting
        /// the <code>includeGlobalResourceTypes</code> field to false.</para></note>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ConfigurationRecorder_RecordingGroup_IncludeGlobalResourceTypes")]
        public System.Boolean? RecordingGroup_IncludeGlobalResourceType { get; set; }
        #endregion
        
        #region Parameter ConfigurationRecorderName
        /// <summary>
        /// <para>
        /// <para>The name of the configuration recorder. Config automatically assigns the name of "default"
        /// when creating the configuration recorder.</para><para>You cannot change the name of the configuration recorder after it has been created.
        /// To change the configuration recorder name, you must delete it and create a new configuration
        /// recorder with a new name. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        [Alias("ConfigurationRecorder_Name")]
        public System.String ConfigurationRecorderName { get; set; }
        #endregion
        
        #region Parameter ExclusionByResourceTypes_ResourceType
        /// <summary>
        /// <para>
        /// <para>A comma-separated list of resource types to exclude from recording by the configuration
        /// recorder.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ConfigurationRecorder_RecordingGroup_ExclusionByResourceTypes_ResourceTypes")]
        public System.String[] ExclusionByResourceTypes_ResourceType { get; set; }
        #endregion
        
        #region Parameter RecordingGroup_ResourceType
        /// <summary>
        /// <para>
        /// <para>A comma-separated list that specifies which resource types Config records.</para><para>Optionally, you can set the <code>useOnly</code> field of <a href="https://docs.aws.amazon.com/config/latest/APIReference/API_RecordingStrategy.html">RecordingStrategy</a>
        /// to <code>INCLUSION_BY_RESOURCE_TYPES</code>.</para><para>To record all configuration changes, set the <code>allSupported</code> field of <a href="https://docs.aws.amazon.com/config/latest/APIReference/API_RecordingGroup.html">RecordingGroup</a>
        /// to <code>true</code>, and either omit this field or don't specify any resource types
        /// in this field. If you set the <code>allSupported</code> field to <code>false</code>
        /// and specify values for <code>resourceTypes</code>, when Config adds support for a
        /// new type of resource, it will not record resources of that type unless you manually
        /// add that type to your recording group.</para><para>For a list of valid <code>resourceTypes</code> values, see the <b>Resource Type Value</b>
        /// column in <a href="https://docs.aws.amazon.com/config/latest/developerguide/resource-config-reference.html#supported-resources">Supported
        /// Amazon Web Services resource Types</a> in the <i>Config developer guide</i>.</para><note><para><b>Region Availability</b></para><para>Before specifying a resource type for Config to track, check <a href="https://docs.aws.amazon.com/config/latest/developerguide/what-is-resource-config-coverage.html">Resource
        /// Coverage by Region Availability</a> to see if the resource type is supported in the
        /// Amazon Web Services Region where you set up Config. If a resource type is supported
        /// by Config in at least one Region, you can enable the recording of that resource type
        /// in all Regions supported by Config, even if the specified resource type is not supported
        /// in the Amazon Web Services Region where you set up Config.</para></note>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ConfigurationRecorder_RecordingGroup_ResourceTypes")]
        public System.String[] RecordingGroup_ResourceType { get; set; }
        #endregion
        
        #region Parameter ConfigurationRecorder_RoleARN
        /// <summary>
        /// <para>
        /// <para>Amazon Resource Name (ARN) of the IAM role assumed by Config and used by the configuration
        /// recorder.</para><note><para>While the API model does not require this field, the server will reject a request
        /// without a defined <code>roleARN</code> for the configuration recorder.</para></note><note><para><b>Pre-existing Config role</b></para><para>If you have used an Amazon Web Services service that uses Config, such as Security
        /// Hub or Control Tower, and an Config role has already been created, make sure that
        /// the IAM role that you use when setting up Config keeps the same minimum permissions
        /// as the already created Config role. You must do this so that the other Amazon Web
        /// Services service continues to run as expected. </para><para>For example, if Control Tower has an IAM role that allows Config to read Amazon Simple
        /// Storage Service (Amazon S3) objects, make sure that the same permissions are granted
        /// within the IAM role you use when setting up Config. Otherwise, it may interfere with
        /// how Control Tower operates. For more information about IAM roles for Config, see <a href="https://docs.aws.amazon.com/config/latest/developerguide/security-iam.html"><b>Identity and Access Management for Config</b></a> in the <i>Config Developer Guide</i>.
        /// </para></note>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ConfigurationRecorder_RoleARN { get; set; }
        #endregion
        
        #region Parameter RecordingStrategy_UseOnly
        /// <summary>
        /// <para>
        /// <para>The recording strategy for the configuration recorder.</para><ul><li><para>If you set this option to <code>ALL_SUPPORTED_RESOURCE_TYPES</code>, Config records
        /// configuration changes for all supported regional resource types. You also must set
        /// the <code>allSupported</code> field of <a href="https://docs.aws.amazon.com/config/latest/APIReference/API_RecordingGroup.html">RecordingGroup</a>
        /// to <code>true</code>.</para><para>When Config adds support for a new type of regional resource, Config automatically
        /// starts recording resources of that type. For a list of supported resource types, see
        /// <a href="https://docs.aws.amazon.com/config/latest/developerguide/resource-config-reference.html#supported-resources">Supported
        /// Resource Types</a> in the <i>Config developer guide</i>.</para></li><li><para>If you set this option to <code>INCLUSION_BY_RESOURCE_TYPES</code>, Config records
        /// configuration changes for only the resource types that you specify in the <code>resourceTypes</code>
        /// field of <a href="https://docs.aws.amazon.com/config/latest/APIReference/API_RecordingGroup.html">RecordingGroup</a>.</para></li><li><para>If you set this option to <code>EXCLUSION_BY_RESOURCE_TYPES</code>, Config records
        /// configuration changes for all supported resource types, except the resource types
        /// that you specify as exemptions to exclude from being recorded in the <code>resourceTypes</code>
        /// field of <a href="https://docs.aws.amazon.com/config/latest/APIReference/API_ExclusionByResourceTypes.html">ExclusionByResourceTypes</a>.</para></li></ul><note><para>The <code>recordingStrategy</code> field is optional when you set the <code>allSupported</code>
        /// field of <a href="https://docs.aws.amazon.com/config/latest/APIReference/API_RecordingGroup.html">RecordingGroup</a>
        /// to <code>true</code>.</para><para>The <code>recordingStrategy</code> field is optional when you list resource types
        /// in the <code>resourceTypes</code> field of <a href="https://docs.aws.amazon.com/config/latest/APIReference/API_RecordingGroup.html">RecordingGroup</a>.</para><para>The <code>recordingStrategy</code> field is required if you list resource types to
        /// exclude from recording in the <code>resourceTypes</code> field of <a href="https://docs.aws.amazon.com/config/latest/APIReference/API_ExclusionByResourceTypes.html">ExclusionByResourceTypes</a>.</para></note><note><para>If you choose <code>EXCLUSION_BY_RESOURCE_TYPES</code> for the recording strategy,
        /// the <code>exclusionByResourceTypes</code> field will override other properties in
        /// the request.</para><para>For example, even if you set <code>includeGlobalResourceTypes</code> to false, global
        /// resource types will still be automatically recorded in this option unless those resource
        /// types are specifically listed as exemptions in the <code>resourceTypes</code> field
        /// of <code>exclusionByResourceTypes</code>.</para><para>By default, if you choose the <code>EXCLUSION_BY_RESOURCE_TYPES</code> recording strategy,
        /// when Config adds support for a new resource type in the Region where you set up the
        /// configuration recorder, including global resource types, Config starts recording resources
        /// of that type automatically.</para></note>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ConfigurationRecorder_RecordingGroup_RecordingStrategy_UseOnly")]
        [AWSConstantClassSource("Amazon.ConfigService.RecordingStrategyType")]
        public Amazon.ConfigService.RecordingStrategyType RecordingStrategy_UseOnly { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The cmdlet doesn't have a return value by default.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.ConfigService.Model.PutConfigurationRecorderResponse).
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the ConfigurationRecorderName parameter.
        /// The -PassThru parameter is deprecated, use -Select '^ConfigurationRecorderName' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^ConfigurationRecorderName' instead. This parameter will be removed in a future version.")]
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public SwitchParameter PassThru { get; set; }
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.ConfigurationRecorderName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Write-CFGConfigurationRecorder (PutConfigurationRecorder)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.ConfigService.Model.PutConfigurationRecorderResponse, WriteCFGConfigurationRecorderCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.ConfigurationRecorderName;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.ConfigurationRecorderName = this.ConfigurationRecorderName;
            context.RecordingGroup_AllSupported = this.RecordingGroup_AllSupported;
            if (this.ExclusionByResourceTypes_ResourceType != null)
            {
                context.ExclusionByResourceTypes_ResourceType = new List<System.String>(this.ExclusionByResourceTypes_ResourceType);
            }
            context.RecordingGroup_IncludeGlobalResourceType = this.RecordingGroup_IncludeGlobalResourceType;
            context.RecordingStrategy_UseOnly = this.RecordingStrategy_UseOnly;
            if (this.RecordingGroup_ResourceType != null)
            {
                context.RecordingGroup_ResourceType = new List<System.String>(this.RecordingGroup_ResourceType);
            }
            context.ConfigurationRecorder_RoleARN = this.ConfigurationRecorder_RoleARN;
            
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
            var request = new Amazon.ConfigService.Model.PutConfigurationRecorderRequest();
            
            
             // populate ConfigurationRecorder
            var requestConfigurationRecorderIsNull = true;
            request.ConfigurationRecorder = new Amazon.ConfigService.Model.ConfigurationRecorder();
            System.String requestConfigurationRecorder_configurationRecorderName = null;
            if (cmdletContext.ConfigurationRecorderName != null)
            {
                requestConfigurationRecorder_configurationRecorderName = cmdletContext.ConfigurationRecorderName;
            }
            if (requestConfigurationRecorder_configurationRecorderName != null)
            {
                request.ConfigurationRecorder.Name = requestConfigurationRecorder_configurationRecorderName;
                requestConfigurationRecorderIsNull = false;
            }
            System.String requestConfigurationRecorder_configurationRecorder_RoleARN = null;
            if (cmdletContext.ConfigurationRecorder_RoleARN != null)
            {
                requestConfigurationRecorder_configurationRecorder_RoleARN = cmdletContext.ConfigurationRecorder_RoleARN;
            }
            if (requestConfigurationRecorder_configurationRecorder_RoleARN != null)
            {
                request.ConfigurationRecorder.RoleARN = requestConfigurationRecorder_configurationRecorder_RoleARN;
                requestConfigurationRecorderIsNull = false;
            }
            Amazon.ConfigService.Model.RecordingGroup requestConfigurationRecorder_configurationRecorder_RecordingGroup = null;
            
             // populate RecordingGroup
            var requestConfigurationRecorder_configurationRecorder_RecordingGroupIsNull = true;
            requestConfigurationRecorder_configurationRecorder_RecordingGroup = new Amazon.ConfigService.Model.RecordingGroup();
            System.Boolean? requestConfigurationRecorder_configurationRecorder_RecordingGroup_recordingGroup_AllSupported = null;
            if (cmdletContext.RecordingGroup_AllSupported != null)
            {
                requestConfigurationRecorder_configurationRecorder_RecordingGroup_recordingGroup_AllSupported = cmdletContext.RecordingGroup_AllSupported.Value;
            }
            if (requestConfigurationRecorder_configurationRecorder_RecordingGroup_recordingGroup_AllSupported != null)
            {
                requestConfigurationRecorder_configurationRecorder_RecordingGroup.AllSupported = requestConfigurationRecorder_configurationRecorder_RecordingGroup_recordingGroup_AllSupported.Value;
                requestConfigurationRecorder_configurationRecorder_RecordingGroupIsNull = false;
            }
            System.Boolean? requestConfigurationRecorder_configurationRecorder_RecordingGroup_recordingGroup_IncludeGlobalResourceType = null;
            if (cmdletContext.RecordingGroup_IncludeGlobalResourceType != null)
            {
                requestConfigurationRecorder_configurationRecorder_RecordingGroup_recordingGroup_IncludeGlobalResourceType = cmdletContext.RecordingGroup_IncludeGlobalResourceType.Value;
            }
            if (requestConfigurationRecorder_configurationRecorder_RecordingGroup_recordingGroup_IncludeGlobalResourceType != null)
            {
                requestConfigurationRecorder_configurationRecorder_RecordingGroup.IncludeGlobalResourceTypes = requestConfigurationRecorder_configurationRecorder_RecordingGroup_recordingGroup_IncludeGlobalResourceType.Value;
                requestConfigurationRecorder_configurationRecorder_RecordingGroupIsNull = false;
            }
            List<System.String> requestConfigurationRecorder_configurationRecorder_RecordingGroup_recordingGroup_ResourceType = null;
            if (cmdletContext.RecordingGroup_ResourceType != null)
            {
                requestConfigurationRecorder_configurationRecorder_RecordingGroup_recordingGroup_ResourceType = cmdletContext.RecordingGroup_ResourceType;
            }
            if (requestConfigurationRecorder_configurationRecorder_RecordingGroup_recordingGroup_ResourceType != null)
            {
                requestConfigurationRecorder_configurationRecorder_RecordingGroup.ResourceTypes = requestConfigurationRecorder_configurationRecorder_RecordingGroup_recordingGroup_ResourceType;
                requestConfigurationRecorder_configurationRecorder_RecordingGroupIsNull = false;
            }
            Amazon.ConfigService.Model.ExclusionByResourceTypes requestConfigurationRecorder_configurationRecorder_RecordingGroup_configurationRecorder_RecordingGroup_ExclusionByResourceTypes = null;
            
             // populate ExclusionByResourceTypes
            var requestConfigurationRecorder_configurationRecorder_RecordingGroup_configurationRecorder_RecordingGroup_ExclusionByResourceTypesIsNull = true;
            requestConfigurationRecorder_configurationRecorder_RecordingGroup_configurationRecorder_RecordingGroup_ExclusionByResourceTypes = new Amazon.ConfigService.Model.ExclusionByResourceTypes();
            List<System.String> requestConfigurationRecorder_configurationRecorder_RecordingGroup_configurationRecorder_RecordingGroup_ExclusionByResourceTypes_exclusionByResourceTypes_ResourceType = null;
            if (cmdletContext.ExclusionByResourceTypes_ResourceType != null)
            {
                requestConfigurationRecorder_configurationRecorder_RecordingGroup_configurationRecorder_RecordingGroup_ExclusionByResourceTypes_exclusionByResourceTypes_ResourceType = cmdletContext.ExclusionByResourceTypes_ResourceType;
            }
            if (requestConfigurationRecorder_configurationRecorder_RecordingGroup_configurationRecorder_RecordingGroup_ExclusionByResourceTypes_exclusionByResourceTypes_ResourceType != null)
            {
                requestConfigurationRecorder_configurationRecorder_RecordingGroup_configurationRecorder_RecordingGroup_ExclusionByResourceTypes.ResourceTypes = requestConfigurationRecorder_configurationRecorder_RecordingGroup_configurationRecorder_RecordingGroup_ExclusionByResourceTypes_exclusionByResourceTypes_ResourceType;
                requestConfigurationRecorder_configurationRecorder_RecordingGroup_configurationRecorder_RecordingGroup_ExclusionByResourceTypesIsNull = false;
            }
             // determine if requestConfigurationRecorder_configurationRecorder_RecordingGroup_configurationRecorder_RecordingGroup_ExclusionByResourceTypes should be set to null
            if (requestConfigurationRecorder_configurationRecorder_RecordingGroup_configurationRecorder_RecordingGroup_ExclusionByResourceTypesIsNull)
            {
                requestConfigurationRecorder_configurationRecorder_RecordingGroup_configurationRecorder_RecordingGroup_ExclusionByResourceTypes = null;
            }
            if (requestConfigurationRecorder_configurationRecorder_RecordingGroup_configurationRecorder_RecordingGroup_ExclusionByResourceTypes != null)
            {
                requestConfigurationRecorder_configurationRecorder_RecordingGroup.ExclusionByResourceTypes = requestConfigurationRecorder_configurationRecorder_RecordingGroup_configurationRecorder_RecordingGroup_ExclusionByResourceTypes;
                requestConfigurationRecorder_configurationRecorder_RecordingGroupIsNull = false;
            }
            Amazon.ConfigService.Model.RecordingStrategy requestConfigurationRecorder_configurationRecorder_RecordingGroup_configurationRecorder_RecordingGroup_RecordingStrategy = null;
            
             // populate RecordingStrategy
            var requestConfigurationRecorder_configurationRecorder_RecordingGroup_configurationRecorder_RecordingGroup_RecordingStrategyIsNull = true;
            requestConfigurationRecorder_configurationRecorder_RecordingGroup_configurationRecorder_RecordingGroup_RecordingStrategy = new Amazon.ConfigService.Model.RecordingStrategy();
            Amazon.ConfigService.RecordingStrategyType requestConfigurationRecorder_configurationRecorder_RecordingGroup_configurationRecorder_RecordingGroup_RecordingStrategy_recordingStrategy_UseOnly = null;
            if (cmdletContext.RecordingStrategy_UseOnly != null)
            {
                requestConfigurationRecorder_configurationRecorder_RecordingGroup_configurationRecorder_RecordingGroup_RecordingStrategy_recordingStrategy_UseOnly = cmdletContext.RecordingStrategy_UseOnly;
            }
            if (requestConfigurationRecorder_configurationRecorder_RecordingGroup_configurationRecorder_RecordingGroup_RecordingStrategy_recordingStrategy_UseOnly != null)
            {
                requestConfigurationRecorder_configurationRecorder_RecordingGroup_configurationRecorder_RecordingGroup_RecordingStrategy.UseOnly = requestConfigurationRecorder_configurationRecorder_RecordingGroup_configurationRecorder_RecordingGroup_RecordingStrategy_recordingStrategy_UseOnly;
                requestConfigurationRecorder_configurationRecorder_RecordingGroup_configurationRecorder_RecordingGroup_RecordingStrategyIsNull = false;
            }
             // determine if requestConfigurationRecorder_configurationRecorder_RecordingGroup_configurationRecorder_RecordingGroup_RecordingStrategy should be set to null
            if (requestConfigurationRecorder_configurationRecorder_RecordingGroup_configurationRecorder_RecordingGroup_RecordingStrategyIsNull)
            {
                requestConfigurationRecorder_configurationRecorder_RecordingGroup_configurationRecorder_RecordingGroup_RecordingStrategy = null;
            }
            if (requestConfigurationRecorder_configurationRecorder_RecordingGroup_configurationRecorder_RecordingGroup_RecordingStrategy != null)
            {
                requestConfigurationRecorder_configurationRecorder_RecordingGroup.RecordingStrategy = requestConfigurationRecorder_configurationRecorder_RecordingGroup_configurationRecorder_RecordingGroup_RecordingStrategy;
                requestConfigurationRecorder_configurationRecorder_RecordingGroupIsNull = false;
            }
             // determine if requestConfigurationRecorder_configurationRecorder_RecordingGroup should be set to null
            if (requestConfigurationRecorder_configurationRecorder_RecordingGroupIsNull)
            {
                requestConfigurationRecorder_configurationRecorder_RecordingGroup = null;
            }
            if (requestConfigurationRecorder_configurationRecorder_RecordingGroup != null)
            {
                request.ConfigurationRecorder.RecordingGroup = requestConfigurationRecorder_configurationRecorder_RecordingGroup;
                requestConfigurationRecorderIsNull = false;
            }
             // determine if request.ConfigurationRecorder should be set to null
            if (requestConfigurationRecorderIsNull)
            {
                request.ConfigurationRecorder = null;
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
        
        private Amazon.ConfigService.Model.PutConfigurationRecorderResponse CallAWSServiceOperation(IAmazonConfigService client, Amazon.ConfigService.Model.PutConfigurationRecorderRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Config", "PutConfigurationRecorder");
            try
            {
                #if DESKTOP
                return client.PutConfigurationRecorder(request);
                #elif CORECLR
                return client.PutConfigurationRecorderAsync(request).GetAwaiter().GetResult();
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
            public System.String ConfigurationRecorderName { get; set; }
            public System.Boolean? RecordingGroup_AllSupported { get; set; }
            public List<System.String> ExclusionByResourceTypes_ResourceType { get; set; }
            public System.Boolean? RecordingGroup_IncludeGlobalResourceType { get; set; }
            public Amazon.ConfigService.RecordingStrategyType RecordingStrategy_UseOnly { get; set; }
            public List<System.String> RecordingGroup_ResourceType { get; set; }
            public System.String ConfigurationRecorder_RoleARN { get; set; }
            public System.Func<Amazon.ConfigService.Model.PutConfigurationRecorderResponse, WriteCFGConfigurationRecorderCmdlet, object> Select { get; set; } =
                (response, cmdlet) => null;
        }
        
    }
}
