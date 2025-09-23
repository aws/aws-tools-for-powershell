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
using System.Threading;
using Amazon.SimpleSystemsManagement;
using Amazon.SimpleSystemsManagement.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.SSM
{
    /// <summary>
    /// A State Manager association defines the state that you want to maintain on your managed
    /// nodes. For example, an association can specify that anti-virus software must be installed
    /// and running on your managed nodes, or that certain ports must be closed. For static
    /// targets, the association specifies a schedule for when the configuration is reapplied.
    /// For dynamic targets, such as an Amazon Web Services resource group or an Amazon Web
    /// Services autoscaling group, State Manager, a tool in Amazon Web Services Systems Manager
    /// applies the configuration when new managed nodes are added to the group. The association
    /// also specifies actions to take when applying the configuration. For example, an association
    /// for anti-virus software might run once a day. If the software isn't installed, then
    /// State Manager installs it. If the software is installed, but the service isn't running,
    /// then the association might instruct State Manager to start the service.
    /// </summary>
    [Cmdlet("New", "SSMAssociation", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.SimpleSystemsManagement.Model.AssociationDescription")]
    [AWSCmdlet("Calls the AWS Systems Manager CreateAssociation API operation.", Operation = new[] {"CreateAssociation"}, SelectReturnType = typeof(Amazon.SimpleSystemsManagement.Model.CreateAssociationResponse))]
    [AWSCmdletOutput("Amazon.SimpleSystemsManagement.Model.AssociationDescription or Amazon.SimpleSystemsManagement.Model.CreateAssociationResponse",
        "This cmdlet returns an Amazon.SimpleSystemsManagement.Model.AssociationDescription object.",
        "The service call response (type Amazon.SimpleSystemsManagement.Model.CreateAssociationResponse) can be returned by specifying '-Select *'."
    )]
    public partial class NewSSMAssociationCmdlet : AmazonSimpleSystemsManagementClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter AlarmConfiguration_Alarm
        /// <summary>
        /// <para>
        /// <para>The name of the CloudWatch alarm specified in the configuration.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("AlarmConfiguration_Alarms")]
        public Amazon.SimpleSystemsManagement.Model.Alarm[] AlarmConfiguration_Alarm { get; set; }
        #endregion
        
        #region Parameter ApplyOnlyAtCronInterval
        /// <summary>
        /// <para>
        /// <para>By default, when you create a new association, the system runs it immediately after
        /// it is created and then according to the schedule you specified and when target changes
        /// are detected. Specify <c>true</c> for <c>ApplyOnlyAtCronInterval</c>if you want the
        /// association to run only according to the schedule you specified.</para><para>For more information, see <a href="https://docs.aws.amazon.com/systems-manager/latest/userguide/state-manager-about.html#state-manager-about-scheduling">Understanding
        /// when associations are applied to resources</a> and <a href="https://docs.aws.amazon.com/systems-manager/latest/userguide/state-manager-about.html#runbook-target-updates">&gt;About
        /// target updates with Automation runbooks</a> in the <i>Amazon Web Services Systems
        /// Manager User Guide</i>.</para><para>This parameter isn't supported for rate expressions.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? ApplyOnlyAtCronInterval { get; set; }
        #endregion
        
        #region Parameter AssociationName
        /// <summary>
        /// <para>
        /// <para>Specify a descriptive name for the association.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String AssociationName { get; set; }
        #endregion
        
        #region Parameter AutomationTargetParameterName
        /// <summary>
        /// <para>
        /// <para>Choose the parameter that will define how your automation will branch out. This target
        /// is required for associations that use an Automation runbook and target resources by
        /// using rate controls. Automation is a tool in Amazon Web Services Systems Manager.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String AutomationTargetParameterName { get; set; }
        #endregion
        
        #region Parameter CalendarName
        /// <summary>
        /// <para>
        /// <para>The names of Amazon Resource Names (ARNs) of the Change Calendar type documents you
        /// want to gate your associations under. The associations only run when that change calendar
        /// is open. For more information, see <a href="https://docs.aws.amazon.com/systems-manager/latest/userguide/systems-manager-change-calendar">Amazon
        /// Web Services Systems Manager Change Calendar</a> in the <i>Amazon Web Services Systems
        /// Manager User Guide</i>.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("CalendarNames")]
        public System.String[] CalendarName { get; set; }
        #endregion
        
        #region Parameter ComplianceSeverity
        /// <summary>
        /// <para>
        /// <para>The severity level to assign to the association.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.SimpleSystemsManagement.AssociationComplianceSeverity")]
        public Amazon.SimpleSystemsManagement.AssociationComplianceSeverity ComplianceSeverity { get; set; }
        #endregion
        
        #region Parameter DocumentVersion
        /// <summary>
        /// <para>
        /// <para>The document version you want to associate with the targets. Can be a specific version
        /// or the default version.</para><important><para>State Manager doesn't support running associations that use a new version of a document
        /// if that document is shared from another account. State Manager always runs the <c>default</c>
        /// version of a document if shared from another account, even though the Systems Manager
        /// console shows that a new version was processed. If you want to run an association
        /// using a new version of a document shared form another account, you must set the document
        /// version to <c>default</c>.</para></important>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String DocumentVersion { get; set; }
        #endregion
        
        #region Parameter Duration
        /// <summary>
        /// <para>
        /// <para>The number of hours the association can run before it is canceled. Duration applies
        /// to associations that are currently running, and any pending and in progress commands
        /// on all targets. If a target was taken offline for the association to run, it is made
        /// available again immediately, without a reboot. </para><para>The <c>Duration</c> parameter applies only when both these conditions are true:</para><ul><li><para>The association for which you specify a duration is cancelable according to the parameters
        /// of the SSM command document or Automation runbook associated with this execution.
        /// </para></li><li><para>The command specifies the <c><a href="https://docs.aws.amazon.com/systems-manager/latest/APIReference/API_CreateAssociation.html#systemsmanager-CreateAssociation-request-ApplyOnlyAtCronInterval">ApplyOnlyAtCronInterval</a></c> parameter, which means that the association doesn't run immediately after it
        /// is created, but only according to the specified schedule.</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? Duration { get; set; }
        #endregion
        
        #region Parameter AlarmConfiguration_IgnorePollAlarmFailure
        /// <summary>
        /// <para>
        /// <para>When this value is <i>true</i>, your automation or command continues to run in cases
        /// where we can’t retrieve alarm status information from CloudWatch. In cases where we
        /// successfully retrieve an alarm status of OK or INSUFFICIENT_DATA, the automation or
        /// command continues to run, regardless of this value. Default is <i>false</i>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? AlarmConfiguration_IgnorePollAlarmFailure { get; set; }
        #endregion
        
        #region Parameter InstanceId
        /// <summary>
        /// <para>
        /// <para>The managed node ID.</para><note><para><c>InstanceId</c> has been deprecated. To specify a managed node ID for an association,
        /// use the <c>Targets</c> parameter. Requests that include the parameter <c>InstanceID</c>
        /// with Systems Manager documents (SSM documents) that use schema version 2.0 or later
        /// will fail. In addition, if you use the parameter <c>InstanceId</c>, you can't use
        /// the parameters <c>AssociationName</c>, <c>DocumentVersion</c>, <c>MaxErrors</c>, <c>MaxConcurrency</c>,
        /// <c>OutputLocation</c>, or <c>ScheduleExpression</c>. To use these parameters, you
        /// must use the <c>Targets</c> parameter.</para></note>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public System.String InstanceId { get; set; }
        #endregion
        
        #region Parameter MaxConcurrency
        /// <summary>
        /// <para>
        /// <para>The maximum number of targets allowed to run the association at the same time. You
        /// can specify a number, for example 10, or a percentage of the target set, for example
        /// 10%. The default value is 100%, which means all targets run the association at the
        /// same time.</para><para>If a new managed node starts and attempts to run an association while Systems Manager
        /// is running <c>MaxConcurrency</c> associations, the association is allowed to run.
        /// During the next association interval, the new managed node will process its association
        /// within the limit specified for <c>MaxConcurrency</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String MaxConcurrency { get; set; }
        #endregion
        
        #region Parameter MaxError
        /// <summary>
        /// <para>
        /// <para>The number of errors that are allowed before the system stops sending requests to
        /// run the association on additional targets. You can specify either an absolute number
        /// of errors, for example 10, or a percentage of the target set, for example 10%. If
        /// you specify 3, for example, the system stops sending requests when the fourth error
        /// is received. If you specify 0, then the system stops sending requests after the first
        /// error is returned. If you run an association on 50 managed nodes and set <c>MaxError</c>
        /// to 10%, then the system stops sending the request when the sixth error is received.</para><para>Executions that are already running an association when <c>MaxErrors</c> is reached
        /// are allowed to complete, but some of these executions may fail as well. If you need
        /// to ensure that there won't be more than max-errors failed executions, set <c>MaxConcurrency</c>
        /// to 1 so that executions proceed one at a time.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MaxErrors")]
        public System.String MaxError { get; set; }
        #endregion
        
        #region Parameter Name
        /// <summary>
        /// <para>
        /// <para>The name of the SSM Command document or Automation runbook that contains the configuration
        /// information for the managed node.</para><para>You can specify Amazon Web Services-predefined documents, documents you created, or
        /// a document that is shared with you from another Amazon Web Services account.</para><para>For Systems Manager documents (SSM documents) that are shared with you from other
        /// Amazon Web Services accounts, you must specify the complete SSM document ARN, in the
        /// following format:</para><para><c>arn:<i>partition</i>:ssm:<i>region</i>:<i>account-id</i>:document/<i>document-name</i></c></para><para>For example:</para><para><c>arn:aws:ssm:us-east-2:12345678912:document/My-Shared-Document</c></para><para>For Amazon Web Services-predefined documents and SSM documents you created in your
        /// account, you only need to specify the document name. For example, <c>AWS-ApplyPatchBaseline</c>
        /// or <c>My-Document</c>.</para>
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
        
        #region Parameter S3Location_OutputS3BucketName
        /// <summary>
        /// <para>
        /// <para>The name of the S3 bucket.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("OutputLocation_S3Location_OutputS3BucketName")]
        public System.String S3Location_OutputS3BucketName { get; set; }
        #endregion
        
        #region Parameter S3Location_OutputS3KeyPrefix
        /// <summary>
        /// <para>
        /// <para>The S3 bucket subfolder.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("OutputLocation_S3Location_OutputS3KeyPrefix")]
        public System.String S3Location_OutputS3KeyPrefix { get; set; }
        #endregion
        
        #region Parameter S3Location_OutputS3Region
        /// <summary>
        /// <para>
        /// <para>The Amazon Web Services Region of the S3 bucket.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("OutputLocation_S3Location_OutputS3Region")]
        public System.String S3Location_OutputS3Region { get; set; }
        #endregion
        
        #region Parameter Parameter
        /// <summary>
        /// <para>
        /// <para>The parameters for the runtime configuration of the document.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Parameters")]
        public System.Collections.Hashtable Parameter { get; set; }
        #endregion
        
        #region Parameter ScheduleExpression
        /// <summary>
        /// <para>
        /// <para>A cron expression when the association will be applied to the targets.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ScheduleExpression { get; set; }
        #endregion
        
        #region Parameter ScheduleOffset
        /// <summary>
        /// <para>
        /// <para>Number of days to wait after the scheduled day to run an association. For example,
        /// if you specified a cron schedule of <c>cron(0 0 ? * THU#2 *)</c>, you could specify
        /// an offset of 3 to run the association each Sunday after the second Thursday of the
        /// month. For more information about cron schedules for associations, see <a href="https://docs.aws.amazon.com/systems-manager/latest/userguide/reference-cron-and-rate-expressions.html">Reference:
        /// Cron and rate expressions for Systems Manager</a> in the <i>Amazon Web Services Systems
        /// Manager User Guide</i>. </para><note><para>To use offsets, you must specify the <c>ApplyOnlyAtCronInterval</c> parameter. This
        /// option tells the system not to run an association immediately after you create it.
        /// </para></note>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? ScheduleOffset { get; set; }
        #endregion
        
        #region Parameter SyncCompliance
        /// <summary>
        /// <para>
        /// <para>The mode for generating association compliance. You can specify <c>AUTO</c> or <c>MANUAL</c>.
        /// In <c>AUTO</c> mode, the system uses the status of the association execution to determine
        /// the compliance status. If the association execution runs successfully, then the association
        /// is <c>COMPLIANT</c>. If the association execution doesn't run successfully, the association
        /// is <c>NON-COMPLIANT</c>.</para><para>In <c>MANUAL</c> mode, you must specify the <c>AssociationId</c> as a parameter for
        /// the <a>PutComplianceItems</a> API operation. In this case, compliance data isn't managed
        /// by State Manager. It is managed by your direct call to the <a>PutComplianceItems</a>
        /// API operation.</para><para>By default, all associations use <c>AUTO</c> mode.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.SimpleSystemsManagement.AssociationSyncCompliance")]
        public Amazon.SimpleSystemsManagement.AssociationSyncCompliance SyncCompliance { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>Adds or overwrites one or more tags for a State Manager association. <i>Tags</i> are
        /// metadata that you can assign to your Amazon Web Services resources. Tags enable you
        /// to categorize your resources in different ways, for example, by purpose, owner, or
        /// environment. Each tag consists of a key and an optional value, both of which you define.
        /// </para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public Amazon.SimpleSystemsManagement.Model.Tag[] Tag { get; set; }
        #endregion
        
        #region Parameter TargetLocation
        /// <summary>
        /// <para>
        /// <para>A location is a combination of Amazon Web Services Regions and Amazon Web Services
        /// accounts where you want to run the association. Use this action to create an association
        /// in multiple Regions and multiple accounts.</para><note><para>The <c>IncludeChildOrganizationUnits</c> parameter is not supported by State Manager.</para></note><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("TargetLocations")]
        public Amazon.SimpleSystemsManagement.Model.TargetLocation[] TargetLocation { get; set; }
        #endregion
        
        #region Parameter TargetMap
        /// <summary>
        /// <para>
        /// <para>A key-value mapping of document parameters to target resources. Both Targets and TargetMaps
        /// can't be specified together.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("TargetMaps")]
        public System.Collections.Hashtable[] TargetMap { get; set; }
        #endregion
        
        #region Parameter Target
        /// <summary>
        /// <para>
        /// <para>The targets for the association. You can target managed nodes by using tags, Amazon
        /// Web Services resource groups, all managed nodes in an Amazon Web Services account,
        /// or individual managed node IDs. You can target all managed nodes in an Amazon Web
        /// Services account by specifying the <c>InstanceIds</c> key with a value of <c>*</c>.
        /// For more information about choosing targets for an association, see <a href="https://docs.aws.amazon.com/systems-manager/latest/userguide/systems-manager-state-manager-targets-and-rate-controls.html">Understanding
        /// targets and rate controls in State Manager associations</a> in the <i>Amazon Web Services
        /// Systems Manager User Guide</i>.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Targets")]
        public Amazon.SimpleSystemsManagement.Model.Target[] Target { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'AssociationDescription'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.SimpleSystemsManagement.Model.CreateAssociationResponse).
        /// Specifying the name of a property of type Amazon.SimpleSystemsManagement.Model.CreateAssociationResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "AssociationDescription";
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
        
        protected override void StopProcessing()
        {
            base.StopProcessing();
            _cancellationTokenSource.Cancel();
        }
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.InstanceId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-SSMAssociation (CreateAssociation)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.SimpleSystemsManagement.Model.CreateAssociationResponse, NewSSMAssociationCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            if (this.AlarmConfiguration_Alarm != null)
            {
                context.AlarmConfiguration_Alarm = new List<Amazon.SimpleSystemsManagement.Model.Alarm>(this.AlarmConfiguration_Alarm);
            }
            context.AlarmConfiguration_IgnorePollAlarmFailure = this.AlarmConfiguration_IgnorePollAlarmFailure;
            context.ApplyOnlyAtCronInterval = this.ApplyOnlyAtCronInterval;
            context.AssociationName = this.AssociationName;
            context.AutomationTargetParameterName = this.AutomationTargetParameterName;
            if (this.CalendarName != null)
            {
                context.CalendarName = new List<System.String>(this.CalendarName);
            }
            context.ComplianceSeverity = this.ComplianceSeverity;
            context.DocumentVersion = this.DocumentVersion;
            context.Duration = this.Duration;
            context.InstanceId = this.InstanceId;
            context.MaxConcurrency = this.MaxConcurrency;
            context.MaxError = this.MaxError;
            context.Name = this.Name;
            #if MODULAR
            if (this.Name == null && ParameterWasBound(nameof(this.Name)))
            {
                WriteWarning("You are passing $null as a value for parameter Name which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.S3Location_OutputS3BucketName = this.S3Location_OutputS3BucketName;
            context.S3Location_OutputS3KeyPrefix = this.S3Location_OutputS3KeyPrefix;
            context.S3Location_OutputS3Region = this.S3Location_OutputS3Region;
            if (this.Parameter != null)
            {
                context.Parameter = new Dictionary<System.String, List<System.String>>(StringComparer.Ordinal);
                foreach (var hashKey in this.Parameter.Keys)
                {
                    object hashValue = this.Parameter[hashKey];
                    if (hashValue == null)
                    {
                        context.Parameter.Add((String)hashKey, null);
                        continue;
                    }
                    var enumerable = SafeEnumerable(hashValue);
                    var valueSet = new List<System.String>();
                    foreach (var s in enumerable)
                    {
                        valueSet.Add((System.String)s);
                    }
                    context.Parameter.Add((String)hashKey, valueSet);
                }
            }
            context.ScheduleExpression = this.ScheduleExpression;
            context.ScheduleOffset = this.ScheduleOffset;
            context.SyncCompliance = this.SyncCompliance;
            if (this.Tag != null)
            {
                context.Tag = new List<Amazon.SimpleSystemsManagement.Model.Tag>(this.Tag);
            }
            if (this.TargetLocation != null)
            {
                context.TargetLocation = new List<Amazon.SimpleSystemsManagement.Model.TargetLocation>(this.TargetLocation);
            }
            if (this.TargetMap != null)
            {
                context.TargetMap = new List<Dictionary<System.String, List<System.String>>>();
                foreach (var hashTable in this.TargetMap)
                {
                    var d = new Dictionary<System.String, List<System.String>>();
                    foreach (var hashKey in hashTable.Keys)
                    {
                        object hashValue = hashTable[hashKey];
                        if (hashValue == null)
                        {
                            d.Add((String)hashKey, null);
                            continue;
                        }
                        var enumerable = SafeEnumerable(hashValue);
                        var valueSet = new List<System.String>();
                        foreach (var s in enumerable)
                        {
                            valueSet.Add((System.String)s);
                        }
                        d.Add((String)hashKey, valueSet);
                    }
                    context.TargetMap.Add(d);
                }
            }
            if (this.Target != null)
            {
                context.Target = new List<Amazon.SimpleSystemsManagement.Model.Target>(this.Target);
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
            var request = new Amazon.SimpleSystemsManagement.Model.CreateAssociationRequest();
            
            
             // populate AlarmConfiguration
            var requestAlarmConfigurationIsNull = true;
            request.AlarmConfiguration = new Amazon.SimpleSystemsManagement.Model.AlarmConfiguration();
            List<Amazon.SimpleSystemsManagement.Model.Alarm> requestAlarmConfiguration_alarmConfiguration_Alarm = null;
            if (cmdletContext.AlarmConfiguration_Alarm != null)
            {
                requestAlarmConfiguration_alarmConfiguration_Alarm = cmdletContext.AlarmConfiguration_Alarm;
            }
            if (requestAlarmConfiguration_alarmConfiguration_Alarm != null)
            {
                request.AlarmConfiguration.Alarms = requestAlarmConfiguration_alarmConfiguration_Alarm;
                requestAlarmConfigurationIsNull = false;
            }
            System.Boolean? requestAlarmConfiguration_alarmConfiguration_IgnorePollAlarmFailure = null;
            if (cmdletContext.AlarmConfiguration_IgnorePollAlarmFailure != null)
            {
                requestAlarmConfiguration_alarmConfiguration_IgnorePollAlarmFailure = cmdletContext.AlarmConfiguration_IgnorePollAlarmFailure.Value;
            }
            if (requestAlarmConfiguration_alarmConfiguration_IgnorePollAlarmFailure != null)
            {
                request.AlarmConfiguration.IgnorePollAlarmFailure = requestAlarmConfiguration_alarmConfiguration_IgnorePollAlarmFailure.Value;
                requestAlarmConfigurationIsNull = false;
            }
             // determine if request.AlarmConfiguration should be set to null
            if (requestAlarmConfigurationIsNull)
            {
                request.AlarmConfiguration = null;
            }
            if (cmdletContext.ApplyOnlyAtCronInterval != null)
            {
                request.ApplyOnlyAtCronInterval = cmdletContext.ApplyOnlyAtCronInterval.Value;
            }
            if (cmdletContext.AssociationName != null)
            {
                request.AssociationName = cmdletContext.AssociationName;
            }
            if (cmdletContext.AutomationTargetParameterName != null)
            {
                request.AutomationTargetParameterName = cmdletContext.AutomationTargetParameterName;
            }
            if (cmdletContext.CalendarName != null)
            {
                request.CalendarNames = cmdletContext.CalendarName;
            }
            if (cmdletContext.ComplianceSeverity != null)
            {
                request.ComplianceSeverity = cmdletContext.ComplianceSeverity;
            }
            if (cmdletContext.DocumentVersion != null)
            {
                request.DocumentVersion = cmdletContext.DocumentVersion;
            }
            if (cmdletContext.Duration != null)
            {
                request.Duration = cmdletContext.Duration.Value;
            }
            if (cmdletContext.InstanceId != null)
            {
                request.InstanceId = cmdletContext.InstanceId;
            }
            if (cmdletContext.MaxConcurrency != null)
            {
                request.MaxConcurrency = cmdletContext.MaxConcurrency;
            }
            if (cmdletContext.MaxError != null)
            {
                request.MaxErrors = cmdletContext.MaxError;
            }
            if (cmdletContext.Name != null)
            {
                request.Name = cmdletContext.Name;
            }
            
             // populate OutputLocation
            var requestOutputLocationIsNull = true;
            request.OutputLocation = new Amazon.SimpleSystemsManagement.Model.InstanceAssociationOutputLocation();
            Amazon.SimpleSystemsManagement.Model.S3OutputLocation requestOutputLocation_outputLocation_S3Location = null;
            
             // populate S3Location
            var requestOutputLocation_outputLocation_S3LocationIsNull = true;
            requestOutputLocation_outputLocation_S3Location = new Amazon.SimpleSystemsManagement.Model.S3OutputLocation();
            System.String requestOutputLocation_outputLocation_S3Location_s3Location_OutputS3BucketName = null;
            if (cmdletContext.S3Location_OutputS3BucketName != null)
            {
                requestOutputLocation_outputLocation_S3Location_s3Location_OutputS3BucketName = cmdletContext.S3Location_OutputS3BucketName;
            }
            if (requestOutputLocation_outputLocation_S3Location_s3Location_OutputS3BucketName != null)
            {
                requestOutputLocation_outputLocation_S3Location.OutputS3BucketName = requestOutputLocation_outputLocation_S3Location_s3Location_OutputS3BucketName;
                requestOutputLocation_outputLocation_S3LocationIsNull = false;
            }
            System.String requestOutputLocation_outputLocation_S3Location_s3Location_OutputS3KeyPrefix = null;
            if (cmdletContext.S3Location_OutputS3KeyPrefix != null)
            {
                requestOutputLocation_outputLocation_S3Location_s3Location_OutputS3KeyPrefix = cmdletContext.S3Location_OutputS3KeyPrefix;
            }
            if (requestOutputLocation_outputLocation_S3Location_s3Location_OutputS3KeyPrefix != null)
            {
                requestOutputLocation_outputLocation_S3Location.OutputS3KeyPrefix = requestOutputLocation_outputLocation_S3Location_s3Location_OutputS3KeyPrefix;
                requestOutputLocation_outputLocation_S3LocationIsNull = false;
            }
            System.String requestOutputLocation_outputLocation_S3Location_s3Location_OutputS3Region = null;
            if (cmdletContext.S3Location_OutputS3Region != null)
            {
                requestOutputLocation_outputLocation_S3Location_s3Location_OutputS3Region = cmdletContext.S3Location_OutputS3Region;
            }
            if (requestOutputLocation_outputLocation_S3Location_s3Location_OutputS3Region != null)
            {
                requestOutputLocation_outputLocation_S3Location.OutputS3Region = requestOutputLocation_outputLocation_S3Location_s3Location_OutputS3Region;
                requestOutputLocation_outputLocation_S3LocationIsNull = false;
            }
             // determine if requestOutputLocation_outputLocation_S3Location should be set to null
            if (requestOutputLocation_outputLocation_S3LocationIsNull)
            {
                requestOutputLocation_outputLocation_S3Location = null;
            }
            if (requestOutputLocation_outputLocation_S3Location != null)
            {
                request.OutputLocation.S3Location = requestOutputLocation_outputLocation_S3Location;
                requestOutputLocationIsNull = false;
            }
             // determine if request.OutputLocation should be set to null
            if (requestOutputLocationIsNull)
            {
                request.OutputLocation = null;
            }
            if (cmdletContext.Parameter != null)
            {
                request.Parameters = cmdletContext.Parameter;
            }
            if (cmdletContext.ScheduleExpression != null)
            {
                request.ScheduleExpression = cmdletContext.ScheduleExpression;
            }
            if (cmdletContext.ScheduleOffset != null)
            {
                request.ScheduleOffset = cmdletContext.ScheduleOffset.Value;
            }
            if (cmdletContext.SyncCompliance != null)
            {
                request.SyncCompliance = cmdletContext.SyncCompliance;
            }
            if (cmdletContext.Tag != null)
            {
                request.Tags = cmdletContext.Tag;
            }
            if (cmdletContext.TargetLocation != null)
            {
                request.TargetLocations = cmdletContext.TargetLocation;
            }
            if (cmdletContext.TargetMap != null)
            {
                request.TargetMaps = cmdletContext.TargetMap;
            }
            if (cmdletContext.Target != null)
            {
                request.Targets = cmdletContext.Target;
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
        
        private Amazon.SimpleSystemsManagement.Model.CreateAssociationResponse CallAWSServiceOperation(IAmazonSimpleSystemsManagement client, Amazon.SimpleSystemsManagement.Model.CreateAssociationRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Systems Manager", "CreateAssociation");
            try
            {
                return client.CreateAssociationAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public List<Amazon.SimpleSystemsManagement.Model.Alarm> AlarmConfiguration_Alarm { get; set; }
            public System.Boolean? AlarmConfiguration_IgnorePollAlarmFailure { get; set; }
            public System.Boolean? ApplyOnlyAtCronInterval { get; set; }
            public System.String AssociationName { get; set; }
            public System.String AutomationTargetParameterName { get; set; }
            public List<System.String> CalendarName { get; set; }
            public Amazon.SimpleSystemsManagement.AssociationComplianceSeverity ComplianceSeverity { get; set; }
            public System.String DocumentVersion { get; set; }
            public System.Int32? Duration { get; set; }
            public System.String InstanceId { get; set; }
            public System.String MaxConcurrency { get; set; }
            public System.String MaxError { get; set; }
            public System.String Name { get; set; }
            public System.String S3Location_OutputS3BucketName { get; set; }
            public System.String S3Location_OutputS3KeyPrefix { get; set; }
            public System.String S3Location_OutputS3Region { get; set; }
            public Dictionary<System.String, List<System.String>> Parameter { get; set; }
            public System.String ScheduleExpression { get; set; }
            public System.Int32? ScheduleOffset { get; set; }
            public Amazon.SimpleSystemsManagement.AssociationSyncCompliance SyncCompliance { get; set; }
            public List<Amazon.SimpleSystemsManagement.Model.Tag> Tag { get; set; }
            public List<Amazon.SimpleSystemsManagement.Model.TargetLocation> TargetLocation { get; set; }
            public List<Dictionary<System.String, List<System.String>>> TargetMap { get; set; }
            public List<Amazon.SimpleSystemsManagement.Model.Target> Target { get; set; }
            public System.Func<Amazon.SimpleSystemsManagement.Model.CreateAssociationResponse, NewSSMAssociationCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.AssociationDescription;
        }
        
    }
}
