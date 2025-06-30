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
using Amazon.ConfigService;
using Amazon.ConfigService.Model;

namespace Amazon.PowerShell.Cmdlets.CFG
{
    /// <summary>
    /// Creates or updates the customer managed configuration recorder.
    /// 
    ///  
    /// <para>
    /// You can use this operation to create a new customer managed configuration recorder
    /// or to update the <c>roleARN</c> and the <c>recordingGroup</c> for an existing customer
    /// managed configuration recorder.
    /// </para><para>
    /// To start the customer managed configuration recorder and begin recording configuration
    /// changes for the resource types you specify, use the <a href="https://docs.aws.amazon.com/config/latest/APIReference/API_StartConfigurationRecorder.html">StartConfigurationRecorder</a>
    /// operation.
    /// </para><para>
    /// For more information, see <a href="https://docs.aws.amazon.com/config/latest/developerguide/stop-start-recorder.html"><b>Working with the Configuration Recorder</b></a> in the <i>Config Developer Guide</i>.
    /// </para><note><para><b>One customer managed configuration recorder per account per Region</b></para><para>
    /// You can create only one customer managed configuration recorder for each account for
    /// each Amazon Web Services Region.
    /// </para><para><b>Default is to record all supported resource types, excluding the global IAM resource
    /// types</b></para><para>
    /// If you have not specified values for the <c>recordingGroup</c> field, the default
    /// for the customer managed configuration recorder is to record all supported resource
    /// types, excluding the global IAM resource types: <c>AWS::IAM::Group</c>, <c>AWS::IAM::Policy</c>,
    /// <c>AWS::IAM::Role</c>, and <c>AWS::IAM::User</c>.
    /// </para><para><b>Tags are added at creation and cannot be updated</b></para><para><c>PutConfigurationRecorder</c> is an idempotent API. Subsequent requests won’t create
    /// a duplicate resource if one was already created. If a following request has different
    /// tags values, Config will ignore these differences and treat it as an idempotent request
    /// of the previous. In this case, tags will not be updated, even if they are different.
    /// </para><para>
    /// Use <a href="https://docs.aws.amazon.com/config/latest/APIReference/API_TagResource.html">TagResource</a>
    /// and <a href="https://docs.aws.amazon.com/config/latest/APIReference/API_UntagResource.html">UntagResource</a>
    /// to update tags after creation.
    /// </para></note>
    /// </summary>
    [Cmdlet("Write", "CFGConfigurationRecorder", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("None")]
    [AWSCmdlet("Calls the AWS Config PutConfigurationRecorder API operation.", Operation = new[] {"PutConfigurationRecorder"}, SelectReturnType = typeof(Amazon.ConfigService.Model.PutConfigurationRecorderResponse))]
    [AWSCmdletOutput("None or Amazon.ConfigService.Model.PutConfigurationRecorderResponse",
        "This cmdlet does not generate any output." +
        "The service response (type Amazon.ConfigService.Model.PutConfigurationRecorderResponse) be returned by specifying '-Select *'."
    )]
    public partial class WriteCFGConfigurationRecorderCmdlet : AmazonConfigServiceClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter RecordingGroup_AllSupported
        /// <summary>
        /// <para>
        /// <para>Specifies whether Config records configuration changes for all supported resource
        /// types, excluding the global IAM resource types.</para><para>If you set this field to <c>true</c>, when Config adds support for a new resource
        /// type, Config starts recording resources of that type automatically.</para><para>If you set this field to <c>true</c>, you cannot enumerate specific resource types
        /// to record in the <c>resourceTypes</c> field of <a href="https://docs.aws.amazon.com/config/latest/APIReference/API_RecordingGroup.html">RecordingGroup</a>,
        /// or to exclude in the <c>resourceTypes</c> field of <a href="https://docs.aws.amazon.com/config/latest/APIReference/API_ExclusionByResourceTypes.html">ExclusionByResourceTypes</a>.</para><note><para><b>Region availability</b></para><para>Check <a href="https://docs.aws.amazon.com/config/latest/developerguide/what-is-resource-config-coverage.html">Resource
        /// Coverage by Region Availability</a> to see if a resource type is supported in the
        /// Amazon Web Services Region where you set up Config.</para></note>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ConfigurationRecorder_RecordingGroup_AllSupported")]
        public System.Boolean? RecordingGroup_AllSupported { get; set; }
        #endregion
        
        #region Parameter ConfigurationRecorder_Arn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the specified configuration recorder.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ConfigurationRecorder_Arn { get; set; }
        #endregion
        
        #region Parameter RecordingGroup_IncludeGlobalResourceType
        /// <summary>
        /// <para>
        /// <para>This option is a bundle which only applies to the global IAM resource types: IAM users,
        /// groups, roles, and customer managed policies. These global IAM resource types can
        /// only be recorded by Config in Regions where Config was available before February 2022.
        /// You cannot be record the global IAM resouce types in Regions supported by Config after
        /// February 2022. For a list of those Regions, see <a href="https://docs.aws.amazon.com/config/latest/developerguide/select-resources.html#select-resources-all">Recording
        /// Amazon Web Services Resources | Global Resources</a>.</para><important><para><b>Aurora global clusters are recorded in all enabled Regions</b></para><para>The <c>AWS::RDS::GlobalCluster</c> resource type will be recorded in all supported
        /// Config Regions where the configuration recorder is enabled, even if <c>includeGlobalResourceTypes</c>
        /// is set<c>false</c>. The <c>includeGlobalResourceTypes</c> option is a bundle which
        /// only applies to IAM users, groups, roles, and customer managed policies. </para><para>If you do not want to record <c>AWS::RDS::GlobalCluster</c> in all enabled Regions,
        /// use one of the following recording strategies:</para><ol><li><para><b>Record all current and future resource types with exclusions</b> (<c>EXCLUSION_BY_RESOURCE_TYPES</c>),
        /// or</para></li><li><para><b>Record specific resource types</b> (<c>INCLUSION_BY_RESOURCE_TYPES</c>).</para></li></ol><para>For more information, see <a href="https://docs.aws.amazon.com/config/latest/developerguide/select-resources.html#select-resources-all">Selecting
        /// Which Resources are Recorded</a> in the <i>Config developer guide</i>.</para></important><important><para><b>includeGlobalResourceTypes and the exclusion recording strategy</b></para><para>The <c>includeGlobalResourceTypes</c> field has no impact on the <c>EXCLUSION_BY_RESOURCE_TYPES</c>
        /// recording strategy. This means that the global IAM resource types (IAM users, groups,
        /// roles, and customer managed policies) will not be automatically added as exclusions
        /// for <c>exclusionByResourceTypes</c> when <c>includeGlobalResourceTypes</c> is set
        /// to <c>false</c>.</para><para>The <c>includeGlobalResourceTypes</c> field should only be used to modify the <c>AllSupported</c>
        /// field, as the default for the <c>AllSupported</c> field is to record configuration
        /// changes for all supported resource types excluding the global IAM resource types.
        /// To include the global IAM resource types when <c>AllSupported</c> is set to <c>true</c>,
        /// make sure to set <c>includeGlobalResourceTypes</c> to <c>true</c>.</para><para>To exclude the global IAM resource types for the <c>EXCLUSION_BY_RESOURCE_TYPES</c>
        /// recording strategy, you need to manually add them to the <c>resourceTypes</c> field
        /// of <c>exclusionByResourceTypes</c>.</para></important><note><para><b>Required and optional fields</b></para><para>Before you set this field to <c>true</c>, set the <c>allSupported</c> field of <a href="https://docs.aws.amazon.com/config/latest/APIReference/API_RecordingGroup.html">RecordingGroup</a>
        /// to <c>true</c>. Optionally, you can set the <c>useOnly</c> field of <a href="https://docs.aws.amazon.com/config/latest/APIReference/API_RecordingStrategy.html">RecordingStrategy</a>
        /// to <c>ALL_SUPPORTED_RESOURCE_TYPES</c>.</para></note><note><para><b>Overriding fields</b></para><para>If you set this field to <c>false</c> but list global IAM resource types in the <c>resourceTypes</c>
        /// field of <a href="https://docs.aws.amazon.com/config/latest/APIReference/API_RecordingGroup.html">RecordingGroup</a>,
        /// Config will still record configuration changes for those specified resource types
        /// <i>regardless</i> of if you set the <c>includeGlobalResourceTypes</c> field to false.</para><para>If you do not want to record configuration changes to the global IAM resource types
        /// (IAM users, groups, roles, and customer managed policies), make sure to not list them
        /// in the <c>resourceTypes</c> field in addition to setting the <c>includeGlobalResourceTypes</c>
        /// field to false.</para></note>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ConfigurationRecorder_RecordingGroup_IncludeGlobalResourceTypes")]
        public System.Boolean? RecordingGroup_IncludeGlobalResourceType { get; set; }
        #endregion
        
        #region Parameter ConfigurationRecorderName
        /// <summary>
        /// <para>
        /// <para>The name of the configuration recorder.</para><para>For customer managed configuration recorders, Config automatically assigns the name
        /// of "default" when creating a configuration recorder if you do not specify a name at
        /// creation time.</para><para>For service-linked configuration recorders, Config automatically assigns a name that
        /// has the prefix "<c>AWS</c>" to a new service-linked configuration recorder.</para><note><para><b>Changing the name of a configuration recorder</b></para><para>To change the name of the customer managed configuration recorder, you must delete
        /// it and create a new customer managed configuration recorder with a new name.</para><para>You cannot change the name of a service-linked configuration recorder.</para></note>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        [Alias("ConfigurationRecorder_Name")]
        public System.String ConfigurationRecorderName { get; set; }
        #endregion
        
        #region Parameter RecordingMode_RecordingFrequency
        /// <summary>
        /// <para>
        /// <para>The default recording frequency that Config uses to record configuration changes.</para><important><para>Daily recording cannot be specified for the following resource types:</para><ul><li><para><c>AWS::Config::ResourceCompliance</c></para></li><li><para><c>AWS::Config::ConformancePackCompliance</c></para></li><li><para><c>AWS::Config::ConfigurationRecorder</c></para></li></ul><para>For the <b>allSupported</b> (<c>ALL_SUPPORTED_RESOURCE_TYPES</c>) recording strategy,
        /// these resource types will be set to Continuous recording.</para></important>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ConfigurationRecorder_RecordingMode_RecordingFrequency")]
        [AWSConstantClassSource("Amazon.ConfigService.RecordingFrequency")]
        public Amazon.ConfigService.RecordingFrequency RecordingMode_RecordingFrequency { get; set; }
        #endregion
        
        #region Parameter RecordingMode_RecordingModeOverride
        /// <summary>
        /// <para>
        /// <para>An array of <c>recordingModeOverride</c> objects for you to specify your overrides
        /// for the recording mode. The <c>recordingModeOverride</c> object in the <c>recordingModeOverrides</c>
        /// array consists of three fields: a <c>description</c>, the new <c>recordingFrequency</c>,
        /// and an array of <c>resourceTypes</c> to override.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ConfigurationRecorder_RecordingMode_RecordingModeOverrides")]
        public Amazon.ConfigService.Model.RecordingModeOverride[] RecordingMode_RecordingModeOverride { get; set; }
        #endregion
        
        #region Parameter ConfigurationRecorder_RecordingScope
        /// <summary>
        /// <para>
        /// <para>Specifies whether the <a href="https://docs.aws.amazon.com/config/latest/APIReference/API_ConfigurationItem.html">ConfigurationItems</a>
        /// in scope for the specified configuration recorder are recorded for free (<c>INTERNAL</c>)
        /// or if it impacts the costs to your bill (<c>PAID</c>).</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.ConfigService.RecordingScope")]
        public Amazon.ConfigService.RecordingScope ConfigurationRecorder_RecordingScope { get; set; }
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
        /// <para>A comma-separated list that specifies which resource types Config records.</para><para>For a list of valid <c>resourceTypes</c> values, see the <b>Resource Type Value</b>
        /// column in <a href="https://docs.aws.amazon.com/config/latest/developerguide/resource-config-reference.html#supported-resources">Supported
        /// Amazon Web Services resource Types</a> in the <i>Config developer guide</i>.</para><note><para><b>Required and optional fields</b></para><para>Optionally, you can set the <c>useOnly</c> field of <a href="https://docs.aws.amazon.com/config/latest/APIReference/API_RecordingStrategy.html">RecordingStrategy</a>
        /// to <c>INCLUSION_BY_RESOURCE_TYPES</c>.</para><para>To record all configuration changes, set the <c>allSupported</c> field of <a href="https://docs.aws.amazon.com/config/latest/APIReference/API_RecordingGroup.html">RecordingGroup</a>
        /// to <c>true</c>, and either omit this field or don't specify any resource types in
        /// this field. If you set the <c>allSupported</c> field to <c>false</c> and specify values
        /// for <c>resourceTypes</c>, when Config adds support for a new type of resource, it
        /// will not record resources of that type unless you manually add that type to your recording
        /// group.</para></note><note><para><b>Region availability</b></para><para>Before specifying a resource type for Config to track, check <a href="https://docs.aws.amazon.com/config/latest/developerguide/what-is-resource-config-coverage.html">Resource
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
        /// <para>The Amazon Resource Name (ARN) of the IAM role assumed by Config and used by the specified
        /// configuration recorder.</para><note><para><b>The server will reject a request without a defined <c>roleARN</c> for the configuration
        /// recorder</b></para><para>While the API model does not require this field, the server will reject a request
        /// without a defined <c>roleARN</c> for the configuration recorder.</para><para><b>Policies and compliance results</b></para><para><a href="https://docs.aws.amazon.com/IAM/latest/UserGuide/access_policies.html">IAM
        /// policies</a> and <a href="https://docs.aws.amazon.com/organizations/latest/userguide/orgs_manage_policies.html">other
        /// policies managed in Organizations</a> can impact whether Config has permissions to
        /// record configuration changes for your resources. Additionally, rules directly evaluate
        /// the configuration of a resource and rules don't take into account these policies when
        /// running evaluations. Make sure that the policies in effect align with how you intend
        /// to use Config.</para><para><b>Keep Minimum Permisions When Reusing an IAM role</b></para><para>If you use an Amazon Web Services service that uses Config, such as Security Hub or
        /// Control Tower, and an IAM role has already been created, make sure that the IAM role
        /// that you use when setting up Config keeps the same minimum permissions as the pre-existing
        /// IAM role. You must do this to ensure that the other Amazon Web Services service continues
        /// to run as expected. </para><para>For example, if Control Tower has an IAM role that allows Config to read S3 objects,
        /// make sure that the same permissions are granted to the IAM role you use when setting
        /// up Config. Otherwise, it may interfere with how Control Tower operates.</para><para><b>The service-linked IAM role for Config must be used for service-linked configuration
        /// recorders</b></para><para>For service-linked configuration recorders, you must use the service-linked IAM role
        /// for Config: <a href="https://docs.aws.amazon.com/config/latest/developerguide/using-service-linked-roles.html">AWSServiceRoleForConfig</a>.</para></note>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ConfigurationRecorder_RoleARN { get; set; }
        #endregion
        
        #region Parameter ConfigurationRecorder_ServicePrincipal
        /// <summary>
        /// <para>
        /// <para>For service-linked configuration recorders, specifies the linked Amazon Web Services
        /// service for the configuration recorder.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ConfigurationRecorder_ServicePrincipal { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>The tags for the customer managed configuration recorder. Each tag consists of a key
        /// and an optional value, both of which you define.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public Amazon.ConfigService.Model.Tag[] Tag { get; set; }
        #endregion
        
        #region Parameter RecordingStrategy_UseOnly
        /// <summary>
        /// <para>
        /// <para>The recording strategy for the configuration recorder.</para><ul><li><para>If you set this option to <c>ALL_SUPPORTED_RESOURCE_TYPES</c>, Config records configuration
        /// changes for all supported resource types, excluding the global IAM resource types.
        /// You also must set the <c>allSupported</c> field of <a href="https://docs.aws.amazon.com/config/latest/APIReference/API_RecordingGroup.html">RecordingGroup</a>
        /// to <c>true</c>. When Config adds support for a new resource type, Config automatically
        /// starts recording resources of that type. For a list of supported resource types, see
        /// <a href="https://docs.aws.amazon.com/config/latest/developerguide/resource-config-reference.html#supported-resources">Supported
        /// Resource Types</a> in the <i>Config developer guide</i>.</para></li><li><para>If you set this option to <c>INCLUSION_BY_RESOURCE_TYPES</c>, Config records configuration
        /// changes for only the resource types that you specify in the <c>resourceTypes</c> field
        /// of <a href="https://docs.aws.amazon.com/config/latest/APIReference/API_RecordingGroup.html">RecordingGroup</a>.</para></li><li><para>If you set this option to <c>EXCLUSION_BY_RESOURCE_TYPES</c>, Config records configuration
        /// changes for all supported resource types, except the resource types that you specify
        /// to exclude from being recorded in the <c>resourceTypes</c> field of <a href="https://docs.aws.amazon.com/config/latest/APIReference/API_ExclusionByResourceTypes.html">ExclusionByResourceTypes</a>.</para></li></ul><note><para><b>Required and optional fields</b></para><para>The <c>recordingStrategy</c> field is optional when you set the <c>allSupported</c>
        /// field of <a href="https://docs.aws.amazon.com/config/latest/APIReference/API_RecordingGroup.html">RecordingGroup</a>
        /// to <c>true</c>.</para><para>The <c>recordingStrategy</c> field is optional when you list resource types in the
        /// <c>resourceTypes</c> field of <a href="https://docs.aws.amazon.com/config/latest/APIReference/API_RecordingGroup.html">RecordingGroup</a>.</para><para>The <c>recordingStrategy</c> field is required if you list resource types to exclude
        /// from recording in the <c>resourceTypes</c> field of <a href="https://docs.aws.amazon.com/config/latest/APIReference/API_ExclusionByResourceTypes.html">ExclusionByResourceTypes</a>.</para></note><note><para><b>Overriding fields</b></para><para>If you choose <c>EXCLUSION_BY_RESOURCE_TYPES</c> for the recording strategy, the <c>exclusionByResourceTypes</c>
        /// field will override other properties in the request.</para><para>For example, even if you set <c>includeGlobalResourceTypes</c> to false, global IAM
        /// resource types will still be automatically recorded in this option unless those resource
        /// types are specifically listed as exclusions in the <c>resourceTypes</c> field of <c>exclusionByResourceTypes</c>.</para></note><note><para><b>Global resource types and the exclusion recording strategy</b></para><para>By default, if you choose the <c>EXCLUSION_BY_RESOURCE_TYPES</c> recording strategy,
        /// when Config adds support for a new resource type in the Region where you set up the
        /// configuration recorder, including global resource types, Config starts recording resources
        /// of that type automatically.</para><para>Unless specifically listed as exclusions, <c>AWS::RDS::GlobalCluster</c> will be recorded
        /// automatically in all supported Config Regions were the configuration recorder is enabled.</para><para>IAM users, groups, roles, and customer managed policies will be recorded in the Region
        /// where you set up the configuration recorder if that is a Region where Config was available
        /// before February 2022. You cannot be record the global IAM resouce types in Regions
        /// supported by Config after February 2022. This list where you cannot record the global
        /// IAM resource types includes the following Regions:</para><ul><li><para>Asia Pacific (Hyderabad)</para></li><li><para>Asia Pacific (Melbourne)</para></li><li><para>Canada West (Calgary)</para></li><li><para>Europe (Spain)</para></li><li><para>Europe (Zurich)</para></li><li><para>Israel (Tel Aviv)</para></li><li><para>Middle East (UAE)</para></li></ul></note>
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
            context.ConfigurationRecorder_Arn = this.ConfigurationRecorder_Arn;
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
            context.RecordingMode_RecordingFrequency = this.RecordingMode_RecordingFrequency;
            if (this.RecordingMode_RecordingModeOverride != null)
            {
                context.RecordingMode_RecordingModeOverride = new List<Amazon.ConfigService.Model.RecordingModeOverride>(this.RecordingMode_RecordingModeOverride);
            }
            context.ConfigurationRecorder_RecordingScope = this.ConfigurationRecorder_RecordingScope;
            context.ConfigurationRecorder_RoleARN = this.ConfigurationRecorder_RoleARN;
            context.ConfigurationRecorder_ServicePrincipal = this.ConfigurationRecorder_ServicePrincipal;
            if (this.Tag != null)
            {
                context.Tag = new List<Amazon.ConfigService.Model.Tag>(this.Tag);
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
            var request = new Amazon.ConfigService.Model.PutConfigurationRecorderRequest();
            
            
             // populate ConfigurationRecorder
            var requestConfigurationRecorderIsNull = true;
            request.ConfigurationRecorder = new Amazon.ConfigService.Model.ConfigurationRecorder();
            System.String requestConfigurationRecorder_configurationRecorder_Arn = null;
            if (cmdletContext.ConfigurationRecorder_Arn != null)
            {
                requestConfigurationRecorder_configurationRecorder_Arn = cmdletContext.ConfigurationRecorder_Arn;
            }
            if (requestConfigurationRecorder_configurationRecorder_Arn != null)
            {
                request.ConfigurationRecorder.Arn = requestConfigurationRecorder_configurationRecorder_Arn;
                requestConfigurationRecorderIsNull = false;
            }
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
            Amazon.ConfigService.RecordingScope requestConfigurationRecorder_configurationRecorder_RecordingScope = null;
            if (cmdletContext.ConfigurationRecorder_RecordingScope != null)
            {
                requestConfigurationRecorder_configurationRecorder_RecordingScope = cmdletContext.ConfigurationRecorder_RecordingScope;
            }
            if (requestConfigurationRecorder_configurationRecorder_RecordingScope != null)
            {
                request.ConfigurationRecorder.RecordingScope = requestConfigurationRecorder_configurationRecorder_RecordingScope;
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
            System.String requestConfigurationRecorder_configurationRecorder_ServicePrincipal = null;
            if (cmdletContext.ConfigurationRecorder_ServicePrincipal != null)
            {
                requestConfigurationRecorder_configurationRecorder_ServicePrincipal = cmdletContext.ConfigurationRecorder_ServicePrincipal;
            }
            if (requestConfigurationRecorder_configurationRecorder_ServicePrincipal != null)
            {
                request.ConfigurationRecorder.ServicePrincipal = requestConfigurationRecorder_configurationRecorder_ServicePrincipal;
                requestConfigurationRecorderIsNull = false;
            }
            Amazon.ConfigService.Model.RecordingMode requestConfigurationRecorder_configurationRecorder_RecordingMode = null;
            
             // populate RecordingMode
            var requestConfigurationRecorder_configurationRecorder_RecordingModeIsNull = true;
            requestConfigurationRecorder_configurationRecorder_RecordingMode = new Amazon.ConfigService.Model.RecordingMode();
            Amazon.ConfigService.RecordingFrequency requestConfigurationRecorder_configurationRecorder_RecordingMode_recordingMode_RecordingFrequency = null;
            if (cmdletContext.RecordingMode_RecordingFrequency != null)
            {
                requestConfigurationRecorder_configurationRecorder_RecordingMode_recordingMode_RecordingFrequency = cmdletContext.RecordingMode_RecordingFrequency;
            }
            if (requestConfigurationRecorder_configurationRecorder_RecordingMode_recordingMode_RecordingFrequency != null)
            {
                requestConfigurationRecorder_configurationRecorder_RecordingMode.RecordingFrequency = requestConfigurationRecorder_configurationRecorder_RecordingMode_recordingMode_RecordingFrequency;
                requestConfigurationRecorder_configurationRecorder_RecordingModeIsNull = false;
            }
            List<Amazon.ConfigService.Model.RecordingModeOverride> requestConfigurationRecorder_configurationRecorder_RecordingMode_recordingMode_RecordingModeOverride = null;
            if (cmdletContext.RecordingMode_RecordingModeOverride != null)
            {
                requestConfigurationRecorder_configurationRecorder_RecordingMode_recordingMode_RecordingModeOverride = cmdletContext.RecordingMode_RecordingModeOverride;
            }
            if (requestConfigurationRecorder_configurationRecorder_RecordingMode_recordingMode_RecordingModeOverride != null)
            {
                requestConfigurationRecorder_configurationRecorder_RecordingMode.RecordingModeOverrides = requestConfigurationRecorder_configurationRecorder_RecordingMode_recordingMode_RecordingModeOverride;
                requestConfigurationRecorder_configurationRecorder_RecordingModeIsNull = false;
            }
             // determine if requestConfigurationRecorder_configurationRecorder_RecordingMode should be set to null
            if (requestConfigurationRecorder_configurationRecorder_RecordingModeIsNull)
            {
                requestConfigurationRecorder_configurationRecorder_RecordingMode = null;
            }
            if (requestConfigurationRecorder_configurationRecorder_RecordingMode != null)
            {
                request.ConfigurationRecorder.RecordingMode = requestConfigurationRecorder_configurationRecorder_RecordingMode;
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
            public System.String ConfigurationRecorder_Arn { get; set; }
            public System.String ConfigurationRecorderName { get; set; }
            public System.Boolean? RecordingGroup_AllSupported { get; set; }
            public List<System.String> ExclusionByResourceTypes_ResourceType { get; set; }
            public System.Boolean? RecordingGroup_IncludeGlobalResourceType { get; set; }
            public Amazon.ConfigService.RecordingStrategyType RecordingStrategy_UseOnly { get; set; }
            public List<System.String> RecordingGroup_ResourceType { get; set; }
            public Amazon.ConfigService.RecordingFrequency RecordingMode_RecordingFrequency { get; set; }
            public List<Amazon.ConfigService.Model.RecordingModeOverride> RecordingMode_RecordingModeOverride { get; set; }
            public Amazon.ConfigService.RecordingScope ConfigurationRecorder_RecordingScope { get; set; }
            public System.String ConfigurationRecorder_RoleARN { get; set; }
            public System.String ConfigurationRecorder_ServicePrincipal { get; set; }
            public List<Amazon.ConfigService.Model.Tag> Tag { get; set; }
            public System.Func<Amazon.ConfigService.Model.PutConfigurationRecorderResponse, WriteCFGConfigurationRecorderCmdlet, object> Select { get; set; } =
                (response, cmdlet) => null;
        }
        
    }
}
