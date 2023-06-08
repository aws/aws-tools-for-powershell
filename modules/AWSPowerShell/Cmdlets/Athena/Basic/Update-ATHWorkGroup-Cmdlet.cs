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
using Amazon.Athena;
using Amazon.Athena.Model;

namespace Amazon.PowerShell.Cmdlets.ATH
{
    /// <summary>
    /// Updates the workgroup with the specified name. The workgroup's name cannot be changed.
    /// Only <code>ConfigurationUpdates</code> can be specified.
    /// </summary>
    [Cmdlet("Update", "ATHWorkGroup", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("None")]
    [AWSCmdlet("Calls the Amazon Athena UpdateWorkGroup API operation.", Operation = new[] {"UpdateWorkGroup"}, SelectReturnType = typeof(Amazon.Athena.Model.UpdateWorkGroupResponse))]
    [AWSCmdletOutput("None or Amazon.Athena.Model.UpdateWorkGroupResponse",
        "This cmdlet does not generate any output." +
        "The service response (type Amazon.Athena.Model.UpdateWorkGroupResponse) can be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class UpdateATHWorkGroupCmdlet : AmazonAthenaClientCmdlet, IExecutor
    {
        
        #region Parameter ConfigurationUpdates_AdditionalConfiguration
        /// <summary>
        /// <para>
        /// <para>Contains a user defined string in JSON format for a Spark-enabled workgroup.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ConfigurationUpdates_AdditionalConfiguration { get; set; }
        #endregion
        
        #region Parameter ConfigurationUpdates_BytesScannedCutoffPerQuery
        /// <summary>
        /// <para>
        /// <para>The upper limit (cutoff) for the amount of bytes a single query in a workgroup is
        /// allowed to scan.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int64? ConfigurationUpdates_BytesScannedCutoffPerQuery { get; set; }
        #endregion
        
        #region Parameter Description
        /// <summary>
        /// <para>
        /// <para>The workgroup description.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Description { get; set; }
        #endregion
        
        #region Parameter EngineVersion_EffectiveEngineVersion
        /// <summary>
        /// <para>
        /// <para>Read only. The engine version on which the query runs. If the user requests a valid
        /// engine version other than Auto, the effective engine version is the same as the engine
        /// version that the user requested. If the user requests Auto, the effective engine version
        /// is chosen by Athena. When a request to update the engine version is made by a <code>CreateWorkGroup</code>
        /// or <code>UpdateWorkGroup</code> operation, the <code>EffectiveEngineVersion</code>
        /// field is ignored.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ConfigurationUpdates_EngineVersion_EffectiveEngineVersion")]
        public System.String EngineVersion_EffectiveEngineVersion { get; set; }
        #endregion
        
        #region Parameter ConfigurationUpdates_EnableMinimumEncryptionConfiguration
        /// <summary>
        /// <para>
        /// <para>Enforces a minimal level of encryption for the workgroup for query and calculation
        /// results that are written to Amazon S3. When enabled, workgroup users can set encryption
        /// only to the minimum level set by the administrator or higher when they submit queries.
        /// This setting does not apply to Spark-enabled workgroups.</para><para>The <code>EnforceWorkGroupConfiguration</code> setting takes precedence over the <code>EnableMinimumEncryptionConfiguration</code>
        /// flag. This means that if <code>EnforceWorkGroupConfiguration</code> is true, the <code>EnableMinimumEncryptionConfiguration</code>
        /// flag is ignored, and the workgroup configuration for encryption is used.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? ConfigurationUpdates_EnableMinimumEncryptionConfiguration { get; set; }
        #endregion
        
        #region Parameter EncryptionConfiguration_EncryptionOption
        /// <summary>
        /// <para>
        /// <para>Indicates whether Amazon S3 server-side encryption with Amazon S3-managed keys (<code>SSE_S3</code>),
        /// server-side encryption with KMS-managed keys (<code>SSE_KMS</code>), or client-side
        /// encryption with KMS-managed keys (<code>CSE_KMS</code>) is used.</para><para>If a query runs in a workgroup and the workgroup overrides client-side settings, then
        /// the workgroup's setting for encryption is used. It specifies whether query results
        /// must be encrypted, for all queries that run in this workgroup. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ConfigurationUpdates_ResultConfigurationUpdates_EncryptionConfiguration_EncryptionOption")]
        [AWSConstantClassSource("Amazon.Athena.EncryptionOption")]
        public Amazon.Athena.EncryptionOption EncryptionConfiguration_EncryptionOption { get; set; }
        #endregion
        
        #region Parameter ConfigurationUpdates_EnforceWorkGroupConfiguration
        /// <summary>
        /// <para>
        /// <para>If set to "true", the settings for the workgroup override client-side settings. If
        /// set to "false" client-side settings are used. For more information, see <a href="https://docs.aws.amazon.com/athena/latest/ug/workgroups-settings-override.html">Workgroup
        /// Settings Override Client-Side Settings</a>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? ConfigurationUpdates_EnforceWorkGroupConfiguration { get; set; }
        #endregion
        
        #region Parameter ConfigurationUpdates_ExecutionRole
        /// <summary>
        /// <para>
        /// <para>Contains the ARN of the execution role for the workgroup</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ConfigurationUpdates_ExecutionRole { get; set; }
        #endregion
        
        #region Parameter ResultConfigurationUpdates_ExpectedBucketOwner
        /// <summary>
        /// <para>
        /// <para>The Amazon Web Services account ID that you expect to be the owner of the Amazon S3
        /// bucket specified by <a>ResultConfiguration$OutputLocation</a>. If set, Athena uses
        /// the value for <code>ExpectedBucketOwner</code> when it makes Amazon S3 calls to your
        /// specified output location. If the <code>ExpectedBucketOwner</code> Amazon Web Services
        /// account ID does not match the actual owner of the Amazon S3 bucket, the call fails
        /// with a permissions error.</para><para>If workgroup settings override client-side settings, then the query uses the <code>ExpectedBucketOwner</code>
        /// setting that is specified for the workgroup, and also uses the location for storing
        /// query results specified in the workgroup. See <a>WorkGroupConfiguration$EnforceWorkGroupConfiguration</a>
        /// and <a href="https://docs.aws.amazon.com/athena/latest/ug/workgroups-settings-override.html">Workgroup
        /// Settings Override Client-Side Settings</a>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ConfigurationUpdates_ResultConfigurationUpdates_ExpectedBucketOwner")]
        public System.String ResultConfigurationUpdates_ExpectedBucketOwner { get; set; }
        #endregion
        
        #region Parameter CustomerContentEncryptionConfiguration_KmsKey
        /// <summary>
        /// <para>
        /// <para>The KMS key that is used to encrypt the user's data stores in Athena.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ConfigurationUpdates_CustomerContentEncryptionConfiguration_KmsKey")]
        public System.String CustomerContentEncryptionConfiguration_KmsKey { get; set; }
        #endregion
        
        #region Parameter EncryptionConfiguration_KmsKey
        /// <summary>
        /// <para>
        /// <para>For <code>SSE_KMS</code> and <code>CSE_KMS</code>, this is the KMS key ARN or ID.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ConfigurationUpdates_ResultConfigurationUpdates_EncryptionConfiguration_KmsKey")]
        public System.String EncryptionConfiguration_KmsKey { get; set; }
        #endregion
        
        #region Parameter ResultConfigurationUpdates_OutputLocation
        /// <summary>
        /// <para>
        /// <para>The location in Amazon S3 where your query and calculation results are stored, such
        /// as <code>s3://path/to/query/bucket/</code>. For more information, see <a href="https://docs.aws.amazon.com/athena/latest/ug/querying.html">Working
        /// with query results, recent queries, and output files</a>. If workgroup settings override
        /// client-side settings, then the query uses the location for the query results and the
        /// encryption configuration that are specified for the workgroup. The "workgroup settings
        /// override" is specified in <code>EnforceWorkGroupConfiguration</code> (true/false)
        /// in the <code>WorkGroupConfiguration</code>. See <a>WorkGroupConfiguration$EnforceWorkGroupConfiguration</a>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ConfigurationUpdates_ResultConfigurationUpdates_OutputLocation")]
        public System.String ResultConfigurationUpdates_OutputLocation { get; set; }
        #endregion
        
        #region Parameter ConfigurationUpdates_PublishCloudWatchMetricsEnabled
        /// <summary>
        /// <para>
        /// <para>Indicates whether this workgroup enables publishing metrics to Amazon CloudWatch.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? ConfigurationUpdates_PublishCloudWatchMetricsEnabled { get; set; }
        #endregion
        
        #region Parameter ResultConfigurationUpdates_RemoveAclConfiguration
        /// <summary>
        /// <para>
        /// <para>If set to <code>true</code>, indicates that the previously-specified ACL configuration
        /// for queries in this workgroup should be ignored and set to null. If set to <code>false</code>
        /// or not set, and a value is present in the <code>AclConfiguration</code> of <code>ResultConfigurationUpdates</code>,
        /// the <code>AclConfiguration</code> in the workgroup's <code>ResultConfiguration</code>
        /// is updated with the new value. For more information, see <a href="https://docs.aws.amazon.com/athena/latest/ug/workgroups-settings-override.html">Workgroup
        /// Settings Override Client-Side Settings</a>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ConfigurationUpdates_ResultConfigurationUpdates_RemoveAclConfiguration")]
        public System.Boolean? ResultConfigurationUpdates_RemoveAclConfiguration { get; set; }
        #endregion
        
        #region Parameter ConfigurationUpdates_RemoveBytesScannedCutoffPerQuery
        /// <summary>
        /// <para>
        /// <para>Indicates that the data usage control limit per query is removed. <a>WorkGroupConfiguration$BytesScannedCutoffPerQuery</a></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? ConfigurationUpdates_RemoveBytesScannedCutoffPerQuery { get; set; }
        #endregion
        
        #region Parameter ConfigurationUpdates_RemoveCustomerContentEncryptionConfiguration
        /// <summary>
        /// <para>
        /// <para>Removes content encryption configuration from an Apache Spark-enabled Athena workgroup.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? ConfigurationUpdates_RemoveCustomerContentEncryptionConfiguration { get; set; }
        #endregion
        
        #region Parameter ResultConfigurationUpdates_RemoveEncryptionConfiguration
        /// <summary>
        /// <para>
        /// <para>If set to "true", indicates that the previously-specified encryption configuration
        /// (also known as the client-side setting) for queries in this workgroup should be ignored
        /// and set to null. If set to "false" or not set, and a value is present in the <code>EncryptionConfiguration</code>
        /// in <code>ResultConfigurationUpdates</code> (the client-side setting), the <code>EncryptionConfiguration</code>
        /// in the workgroup's <code>ResultConfiguration</code> will be updated with the new value.
        /// For more information, see <a href="https://docs.aws.amazon.com/athena/latest/ug/workgroups-settings-override.html">Workgroup
        /// Settings Override Client-Side Settings</a>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ConfigurationUpdates_ResultConfigurationUpdates_RemoveEncryptionConfiguration")]
        public System.Boolean? ResultConfigurationUpdates_RemoveEncryptionConfiguration { get; set; }
        #endregion
        
        #region Parameter ResultConfigurationUpdates_RemoveExpectedBucketOwner
        /// <summary>
        /// <para>
        /// <para>If set to "true", removes the Amazon Web Services account ID previously specified
        /// for <a>ResultConfiguration$ExpectedBucketOwner</a>. If set to "false" or not set,
        /// and a value is present in the <code>ExpectedBucketOwner</code> in <code>ResultConfigurationUpdates</code>
        /// (the client-side setting), the <code>ExpectedBucketOwner</code> in the workgroup's
        /// <code>ResultConfiguration</code> is updated with the new value. For more information,
        /// see <a href="https://docs.aws.amazon.com/athena/latest/ug/workgroups-settings-override.html">Workgroup
        /// Settings Override Client-Side Settings</a>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ConfigurationUpdates_ResultConfigurationUpdates_RemoveExpectedBucketOwner")]
        public System.Boolean? ResultConfigurationUpdates_RemoveExpectedBucketOwner { get; set; }
        #endregion
        
        #region Parameter ResultConfigurationUpdates_RemoveOutputLocation
        /// <summary>
        /// <para>
        /// <para>If set to "true", indicates that the previously-specified query results location (also
        /// known as a client-side setting) for queries in this workgroup should be ignored and
        /// set to null. If set to "false" or not set, and a value is present in the <code>OutputLocation</code>
        /// in <code>ResultConfigurationUpdates</code> (the client-side setting), the <code>OutputLocation</code>
        /// in the workgroup's <code>ResultConfiguration</code> will be updated with the new value.
        /// For more information, see <a href="https://docs.aws.amazon.com/athena/latest/ug/workgroups-settings-override.html">Workgroup
        /// Settings Override Client-Side Settings</a>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ConfigurationUpdates_ResultConfigurationUpdates_RemoveOutputLocation")]
        public System.Boolean? ResultConfigurationUpdates_RemoveOutputLocation { get; set; }
        #endregion
        
        #region Parameter ConfigurationUpdates_RequesterPaysEnabled
        /// <summary>
        /// <para>
        /// <para>If set to <code>true</code>, allows members assigned to a workgroup to specify Amazon
        /// S3 Requester Pays buckets in queries. If set to <code>false</code>, workgroup members
        /// cannot query data from Requester Pays buckets, and queries that retrieve data from
        /// Requester Pays buckets cause an error. The default is <code>false</code>. For more
        /// information about Requester Pays buckets, see <a href="https://docs.aws.amazon.com/AmazonS3/latest/dev/RequesterPaysBuckets.html">Requester
        /// Pays Buckets</a> in the <i>Amazon Simple Storage Service Developer Guide</i>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? ConfigurationUpdates_RequesterPaysEnabled { get; set; }
        #endregion
        
        #region Parameter AclConfiguration_S3AclOption
        /// <summary>
        /// <para>
        /// <para>The Amazon S3 canned ACL that Athena should specify when storing query results. Currently
        /// the only supported canned ACL is <code>BUCKET_OWNER_FULL_CONTROL</code>. If a query
        /// runs in a workgroup and the workgroup overrides client-side settings, then the Amazon
        /// S3 canned ACL specified in the workgroup's settings is used for all queries that run
        /// in the workgroup. For more information about Amazon S3 canned ACLs, see <a href="https://docs.aws.amazon.com/AmazonS3/latest/userguide/acl-overview.html#canned-acl">Canned
        /// ACL</a> in the <i>Amazon S3 User Guide</i>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ConfigurationUpdates_ResultConfigurationUpdates_AclConfiguration_S3AclOption")]
        [AWSConstantClassSource("Amazon.Athena.S3AclOption")]
        public Amazon.Athena.S3AclOption AclConfiguration_S3AclOption { get; set; }
        #endregion
        
        #region Parameter EngineVersion_SelectedEngineVersion
        /// <summary>
        /// <para>
        /// <para>The engine version requested by the user. Possible values are determined by the output
        /// of <code>ListEngineVersions</code>, including AUTO. The default is AUTO.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ConfigurationUpdates_EngineVersion_SelectedEngineVersion")]
        public System.String EngineVersion_SelectedEngineVersion { get; set; }
        #endregion
        
        #region Parameter State
        /// <summary>
        /// <para>
        /// <para>The workgroup state that will be updated for the given workgroup.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.Athena.WorkGroupState")]
        public Amazon.Athena.WorkGroupState State { get; set; }
        #endregion
        
        #region Parameter WorkGroup
        /// <summary>
        /// <para>
        /// <para>The specified workgroup that will be updated.</para>
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
        public System.String WorkGroup { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The cmdlet doesn't have a return value by default.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Athena.Model.UpdateWorkGroupResponse).
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the WorkGroup parameter.
        /// The -PassThru parameter is deprecated, use -Select '^WorkGroup' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^WorkGroup' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.WorkGroup), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-ATHWorkGroup (UpdateWorkGroup)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Athena.Model.UpdateWorkGroupResponse, UpdateATHWorkGroupCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.WorkGroup;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.ConfigurationUpdates_AdditionalConfiguration = this.ConfigurationUpdates_AdditionalConfiguration;
            context.ConfigurationUpdates_BytesScannedCutoffPerQuery = this.ConfigurationUpdates_BytesScannedCutoffPerQuery;
            context.CustomerContentEncryptionConfiguration_KmsKey = this.CustomerContentEncryptionConfiguration_KmsKey;
            context.ConfigurationUpdates_EnableMinimumEncryptionConfiguration = this.ConfigurationUpdates_EnableMinimumEncryptionConfiguration;
            context.ConfigurationUpdates_EnforceWorkGroupConfiguration = this.ConfigurationUpdates_EnforceWorkGroupConfiguration;
            context.EngineVersion_EffectiveEngineVersion = this.EngineVersion_EffectiveEngineVersion;
            context.EngineVersion_SelectedEngineVersion = this.EngineVersion_SelectedEngineVersion;
            context.ConfigurationUpdates_ExecutionRole = this.ConfigurationUpdates_ExecutionRole;
            context.ConfigurationUpdates_PublishCloudWatchMetricsEnabled = this.ConfigurationUpdates_PublishCloudWatchMetricsEnabled;
            context.ConfigurationUpdates_RemoveBytesScannedCutoffPerQuery = this.ConfigurationUpdates_RemoveBytesScannedCutoffPerQuery;
            context.ConfigurationUpdates_RemoveCustomerContentEncryptionConfiguration = this.ConfigurationUpdates_RemoveCustomerContentEncryptionConfiguration;
            context.ConfigurationUpdates_RequesterPaysEnabled = this.ConfigurationUpdates_RequesterPaysEnabled;
            context.AclConfiguration_S3AclOption = this.AclConfiguration_S3AclOption;
            context.EncryptionConfiguration_EncryptionOption = this.EncryptionConfiguration_EncryptionOption;
            context.EncryptionConfiguration_KmsKey = this.EncryptionConfiguration_KmsKey;
            context.ResultConfigurationUpdates_ExpectedBucketOwner = this.ResultConfigurationUpdates_ExpectedBucketOwner;
            context.ResultConfigurationUpdates_OutputLocation = this.ResultConfigurationUpdates_OutputLocation;
            context.ResultConfigurationUpdates_RemoveAclConfiguration = this.ResultConfigurationUpdates_RemoveAclConfiguration;
            context.ResultConfigurationUpdates_RemoveEncryptionConfiguration = this.ResultConfigurationUpdates_RemoveEncryptionConfiguration;
            context.ResultConfigurationUpdates_RemoveExpectedBucketOwner = this.ResultConfigurationUpdates_RemoveExpectedBucketOwner;
            context.ResultConfigurationUpdates_RemoveOutputLocation = this.ResultConfigurationUpdates_RemoveOutputLocation;
            context.Description = this.Description;
            context.State = this.State;
            context.WorkGroup = this.WorkGroup;
            #if MODULAR
            if (this.WorkGroup == null && ParameterWasBound(nameof(this.WorkGroup)))
            {
                WriteWarning("You are passing $null as a value for parameter WorkGroup which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.Athena.Model.UpdateWorkGroupRequest();
            
            
             // populate ConfigurationUpdates
            var requestConfigurationUpdatesIsNull = true;
            request.ConfigurationUpdates = new Amazon.Athena.Model.WorkGroupConfigurationUpdates();
            System.String requestConfigurationUpdates_configurationUpdates_AdditionalConfiguration = null;
            if (cmdletContext.ConfigurationUpdates_AdditionalConfiguration != null)
            {
                requestConfigurationUpdates_configurationUpdates_AdditionalConfiguration = cmdletContext.ConfigurationUpdates_AdditionalConfiguration;
            }
            if (requestConfigurationUpdates_configurationUpdates_AdditionalConfiguration != null)
            {
                request.ConfigurationUpdates.AdditionalConfiguration = requestConfigurationUpdates_configurationUpdates_AdditionalConfiguration;
                requestConfigurationUpdatesIsNull = false;
            }
            System.Int64? requestConfigurationUpdates_configurationUpdates_BytesScannedCutoffPerQuery = null;
            if (cmdletContext.ConfigurationUpdates_BytesScannedCutoffPerQuery != null)
            {
                requestConfigurationUpdates_configurationUpdates_BytesScannedCutoffPerQuery = cmdletContext.ConfigurationUpdates_BytesScannedCutoffPerQuery.Value;
            }
            if (requestConfigurationUpdates_configurationUpdates_BytesScannedCutoffPerQuery != null)
            {
                request.ConfigurationUpdates.BytesScannedCutoffPerQuery = requestConfigurationUpdates_configurationUpdates_BytesScannedCutoffPerQuery.Value;
                requestConfigurationUpdatesIsNull = false;
            }
            System.Boolean? requestConfigurationUpdates_configurationUpdates_EnableMinimumEncryptionConfiguration = null;
            if (cmdletContext.ConfigurationUpdates_EnableMinimumEncryptionConfiguration != null)
            {
                requestConfigurationUpdates_configurationUpdates_EnableMinimumEncryptionConfiguration = cmdletContext.ConfigurationUpdates_EnableMinimumEncryptionConfiguration.Value;
            }
            if (requestConfigurationUpdates_configurationUpdates_EnableMinimumEncryptionConfiguration != null)
            {
                request.ConfigurationUpdates.EnableMinimumEncryptionConfiguration = requestConfigurationUpdates_configurationUpdates_EnableMinimumEncryptionConfiguration.Value;
                requestConfigurationUpdatesIsNull = false;
            }
            System.Boolean? requestConfigurationUpdates_configurationUpdates_EnforceWorkGroupConfiguration = null;
            if (cmdletContext.ConfigurationUpdates_EnforceWorkGroupConfiguration != null)
            {
                requestConfigurationUpdates_configurationUpdates_EnforceWorkGroupConfiguration = cmdletContext.ConfigurationUpdates_EnforceWorkGroupConfiguration.Value;
            }
            if (requestConfigurationUpdates_configurationUpdates_EnforceWorkGroupConfiguration != null)
            {
                request.ConfigurationUpdates.EnforceWorkGroupConfiguration = requestConfigurationUpdates_configurationUpdates_EnforceWorkGroupConfiguration.Value;
                requestConfigurationUpdatesIsNull = false;
            }
            System.String requestConfigurationUpdates_configurationUpdates_ExecutionRole = null;
            if (cmdletContext.ConfigurationUpdates_ExecutionRole != null)
            {
                requestConfigurationUpdates_configurationUpdates_ExecutionRole = cmdletContext.ConfigurationUpdates_ExecutionRole;
            }
            if (requestConfigurationUpdates_configurationUpdates_ExecutionRole != null)
            {
                request.ConfigurationUpdates.ExecutionRole = requestConfigurationUpdates_configurationUpdates_ExecutionRole;
                requestConfigurationUpdatesIsNull = false;
            }
            System.Boolean? requestConfigurationUpdates_configurationUpdates_PublishCloudWatchMetricsEnabled = null;
            if (cmdletContext.ConfigurationUpdates_PublishCloudWatchMetricsEnabled != null)
            {
                requestConfigurationUpdates_configurationUpdates_PublishCloudWatchMetricsEnabled = cmdletContext.ConfigurationUpdates_PublishCloudWatchMetricsEnabled.Value;
            }
            if (requestConfigurationUpdates_configurationUpdates_PublishCloudWatchMetricsEnabled != null)
            {
                request.ConfigurationUpdates.PublishCloudWatchMetricsEnabled = requestConfigurationUpdates_configurationUpdates_PublishCloudWatchMetricsEnabled.Value;
                requestConfigurationUpdatesIsNull = false;
            }
            System.Boolean? requestConfigurationUpdates_configurationUpdates_RemoveBytesScannedCutoffPerQuery = null;
            if (cmdletContext.ConfigurationUpdates_RemoveBytesScannedCutoffPerQuery != null)
            {
                requestConfigurationUpdates_configurationUpdates_RemoveBytesScannedCutoffPerQuery = cmdletContext.ConfigurationUpdates_RemoveBytesScannedCutoffPerQuery.Value;
            }
            if (requestConfigurationUpdates_configurationUpdates_RemoveBytesScannedCutoffPerQuery != null)
            {
                request.ConfigurationUpdates.RemoveBytesScannedCutoffPerQuery = requestConfigurationUpdates_configurationUpdates_RemoveBytesScannedCutoffPerQuery.Value;
                requestConfigurationUpdatesIsNull = false;
            }
            System.Boolean? requestConfigurationUpdates_configurationUpdates_RemoveCustomerContentEncryptionConfiguration = null;
            if (cmdletContext.ConfigurationUpdates_RemoveCustomerContentEncryptionConfiguration != null)
            {
                requestConfigurationUpdates_configurationUpdates_RemoveCustomerContentEncryptionConfiguration = cmdletContext.ConfigurationUpdates_RemoveCustomerContentEncryptionConfiguration.Value;
            }
            if (requestConfigurationUpdates_configurationUpdates_RemoveCustomerContentEncryptionConfiguration != null)
            {
                request.ConfigurationUpdates.RemoveCustomerContentEncryptionConfiguration = requestConfigurationUpdates_configurationUpdates_RemoveCustomerContentEncryptionConfiguration.Value;
                requestConfigurationUpdatesIsNull = false;
            }
            System.Boolean? requestConfigurationUpdates_configurationUpdates_RequesterPaysEnabled = null;
            if (cmdletContext.ConfigurationUpdates_RequesterPaysEnabled != null)
            {
                requestConfigurationUpdates_configurationUpdates_RequesterPaysEnabled = cmdletContext.ConfigurationUpdates_RequesterPaysEnabled.Value;
            }
            if (requestConfigurationUpdates_configurationUpdates_RequesterPaysEnabled != null)
            {
                request.ConfigurationUpdates.RequesterPaysEnabled = requestConfigurationUpdates_configurationUpdates_RequesterPaysEnabled.Value;
                requestConfigurationUpdatesIsNull = false;
            }
            Amazon.Athena.Model.CustomerContentEncryptionConfiguration requestConfigurationUpdates_configurationUpdates_CustomerContentEncryptionConfiguration = null;
            
             // populate CustomerContentEncryptionConfiguration
            var requestConfigurationUpdates_configurationUpdates_CustomerContentEncryptionConfigurationIsNull = true;
            requestConfigurationUpdates_configurationUpdates_CustomerContentEncryptionConfiguration = new Amazon.Athena.Model.CustomerContentEncryptionConfiguration();
            System.String requestConfigurationUpdates_configurationUpdates_CustomerContentEncryptionConfiguration_customerContentEncryptionConfiguration_KmsKey = null;
            if (cmdletContext.CustomerContentEncryptionConfiguration_KmsKey != null)
            {
                requestConfigurationUpdates_configurationUpdates_CustomerContentEncryptionConfiguration_customerContentEncryptionConfiguration_KmsKey = cmdletContext.CustomerContentEncryptionConfiguration_KmsKey;
            }
            if (requestConfigurationUpdates_configurationUpdates_CustomerContentEncryptionConfiguration_customerContentEncryptionConfiguration_KmsKey != null)
            {
                requestConfigurationUpdates_configurationUpdates_CustomerContentEncryptionConfiguration.KmsKey = requestConfigurationUpdates_configurationUpdates_CustomerContentEncryptionConfiguration_customerContentEncryptionConfiguration_KmsKey;
                requestConfigurationUpdates_configurationUpdates_CustomerContentEncryptionConfigurationIsNull = false;
            }
             // determine if requestConfigurationUpdates_configurationUpdates_CustomerContentEncryptionConfiguration should be set to null
            if (requestConfigurationUpdates_configurationUpdates_CustomerContentEncryptionConfigurationIsNull)
            {
                requestConfigurationUpdates_configurationUpdates_CustomerContentEncryptionConfiguration = null;
            }
            if (requestConfigurationUpdates_configurationUpdates_CustomerContentEncryptionConfiguration != null)
            {
                request.ConfigurationUpdates.CustomerContentEncryptionConfiguration = requestConfigurationUpdates_configurationUpdates_CustomerContentEncryptionConfiguration;
                requestConfigurationUpdatesIsNull = false;
            }
            Amazon.Athena.Model.EngineVersion requestConfigurationUpdates_configurationUpdates_EngineVersion = null;
            
             // populate EngineVersion
            var requestConfigurationUpdates_configurationUpdates_EngineVersionIsNull = true;
            requestConfigurationUpdates_configurationUpdates_EngineVersion = new Amazon.Athena.Model.EngineVersion();
            System.String requestConfigurationUpdates_configurationUpdates_EngineVersion_engineVersion_EffectiveEngineVersion = null;
            if (cmdletContext.EngineVersion_EffectiveEngineVersion != null)
            {
                requestConfigurationUpdates_configurationUpdates_EngineVersion_engineVersion_EffectiveEngineVersion = cmdletContext.EngineVersion_EffectiveEngineVersion;
            }
            if (requestConfigurationUpdates_configurationUpdates_EngineVersion_engineVersion_EffectiveEngineVersion != null)
            {
                requestConfigurationUpdates_configurationUpdates_EngineVersion.EffectiveEngineVersion = requestConfigurationUpdates_configurationUpdates_EngineVersion_engineVersion_EffectiveEngineVersion;
                requestConfigurationUpdates_configurationUpdates_EngineVersionIsNull = false;
            }
            System.String requestConfigurationUpdates_configurationUpdates_EngineVersion_engineVersion_SelectedEngineVersion = null;
            if (cmdletContext.EngineVersion_SelectedEngineVersion != null)
            {
                requestConfigurationUpdates_configurationUpdates_EngineVersion_engineVersion_SelectedEngineVersion = cmdletContext.EngineVersion_SelectedEngineVersion;
            }
            if (requestConfigurationUpdates_configurationUpdates_EngineVersion_engineVersion_SelectedEngineVersion != null)
            {
                requestConfigurationUpdates_configurationUpdates_EngineVersion.SelectedEngineVersion = requestConfigurationUpdates_configurationUpdates_EngineVersion_engineVersion_SelectedEngineVersion;
                requestConfigurationUpdates_configurationUpdates_EngineVersionIsNull = false;
            }
             // determine if requestConfigurationUpdates_configurationUpdates_EngineVersion should be set to null
            if (requestConfigurationUpdates_configurationUpdates_EngineVersionIsNull)
            {
                requestConfigurationUpdates_configurationUpdates_EngineVersion = null;
            }
            if (requestConfigurationUpdates_configurationUpdates_EngineVersion != null)
            {
                request.ConfigurationUpdates.EngineVersion = requestConfigurationUpdates_configurationUpdates_EngineVersion;
                requestConfigurationUpdatesIsNull = false;
            }
            Amazon.Athena.Model.ResultConfigurationUpdates requestConfigurationUpdates_configurationUpdates_ResultConfigurationUpdates = null;
            
             // populate ResultConfigurationUpdates
            var requestConfigurationUpdates_configurationUpdates_ResultConfigurationUpdatesIsNull = true;
            requestConfigurationUpdates_configurationUpdates_ResultConfigurationUpdates = new Amazon.Athena.Model.ResultConfigurationUpdates();
            System.String requestConfigurationUpdates_configurationUpdates_ResultConfigurationUpdates_resultConfigurationUpdates_ExpectedBucketOwner = null;
            if (cmdletContext.ResultConfigurationUpdates_ExpectedBucketOwner != null)
            {
                requestConfigurationUpdates_configurationUpdates_ResultConfigurationUpdates_resultConfigurationUpdates_ExpectedBucketOwner = cmdletContext.ResultConfigurationUpdates_ExpectedBucketOwner;
            }
            if (requestConfigurationUpdates_configurationUpdates_ResultConfigurationUpdates_resultConfigurationUpdates_ExpectedBucketOwner != null)
            {
                requestConfigurationUpdates_configurationUpdates_ResultConfigurationUpdates.ExpectedBucketOwner = requestConfigurationUpdates_configurationUpdates_ResultConfigurationUpdates_resultConfigurationUpdates_ExpectedBucketOwner;
                requestConfigurationUpdates_configurationUpdates_ResultConfigurationUpdatesIsNull = false;
            }
            System.String requestConfigurationUpdates_configurationUpdates_ResultConfigurationUpdates_resultConfigurationUpdates_OutputLocation = null;
            if (cmdletContext.ResultConfigurationUpdates_OutputLocation != null)
            {
                requestConfigurationUpdates_configurationUpdates_ResultConfigurationUpdates_resultConfigurationUpdates_OutputLocation = cmdletContext.ResultConfigurationUpdates_OutputLocation;
            }
            if (requestConfigurationUpdates_configurationUpdates_ResultConfigurationUpdates_resultConfigurationUpdates_OutputLocation != null)
            {
                requestConfigurationUpdates_configurationUpdates_ResultConfigurationUpdates.OutputLocation = requestConfigurationUpdates_configurationUpdates_ResultConfigurationUpdates_resultConfigurationUpdates_OutputLocation;
                requestConfigurationUpdates_configurationUpdates_ResultConfigurationUpdatesIsNull = false;
            }
            System.Boolean? requestConfigurationUpdates_configurationUpdates_ResultConfigurationUpdates_resultConfigurationUpdates_RemoveAclConfiguration = null;
            if (cmdletContext.ResultConfigurationUpdates_RemoveAclConfiguration != null)
            {
                requestConfigurationUpdates_configurationUpdates_ResultConfigurationUpdates_resultConfigurationUpdates_RemoveAclConfiguration = cmdletContext.ResultConfigurationUpdates_RemoveAclConfiguration.Value;
            }
            if (requestConfigurationUpdates_configurationUpdates_ResultConfigurationUpdates_resultConfigurationUpdates_RemoveAclConfiguration != null)
            {
                requestConfigurationUpdates_configurationUpdates_ResultConfigurationUpdates.RemoveAclConfiguration = requestConfigurationUpdates_configurationUpdates_ResultConfigurationUpdates_resultConfigurationUpdates_RemoveAclConfiguration.Value;
                requestConfigurationUpdates_configurationUpdates_ResultConfigurationUpdatesIsNull = false;
            }
            System.Boolean? requestConfigurationUpdates_configurationUpdates_ResultConfigurationUpdates_resultConfigurationUpdates_RemoveEncryptionConfiguration = null;
            if (cmdletContext.ResultConfigurationUpdates_RemoveEncryptionConfiguration != null)
            {
                requestConfigurationUpdates_configurationUpdates_ResultConfigurationUpdates_resultConfigurationUpdates_RemoveEncryptionConfiguration = cmdletContext.ResultConfigurationUpdates_RemoveEncryptionConfiguration.Value;
            }
            if (requestConfigurationUpdates_configurationUpdates_ResultConfigurationUpdates_resultConfigurationUpdates_RemoveEncryptionConfiguration != null)
            {
                requestConfigurationUpdates_configurationUpdates_ResultConfigurationUpdates.RemoveEncryptionConfiguration = requestConfigurationUpdates_configurationUpdates_ResultConfigurationUpdates_resultConfigurationUpdates_RemoveEncryptionConfiguration.Value;
                requestConfigurationUpdates_configurationUpdates_ResultConfigurationUpdatesIsNull = false;
            }
            System.Boolean? requestConfigurationUpdates_configurationUpdates_ResultConfigurationUpdates_resultConfigurationUpdates_RemoveExpectedBucketOwner = null;
            if (cmdletContext.ResultConfigurationUpdates_RemoveExpectedBucketOwner != null)
            {
                requestConfigurationUpdates_configurationUpdates_ResultConfigurationUpdates_resultConfigurationUpdates_RemoveExpectedBucketOwner = cmdletContext.ResultConfigurationUpdates_RemoveExpectedBucketOwner.Value;
            }
            if (requestConfigurationUpdates_configurationUpdates_ResultConfigurationUpdates_resultConfigurationUpdates_RemoveExpectedBucketOwner != null)
            {
                requestConfigurationUpdates_configurationUpdates_ResultConfigurationUpdates.RemoveExpectedBucketOwner = requestConfigurationUpdates_configurationUpdates_ResultConfigurationUpdates_resultConfigurationUpdates_RemoveExpectedBucketOwner.Value;
                requestConfigurationUpdates_configurationUpdates_ResultConfigurationUpdatesIsNull = false;
            }
            System.Boolean? requestConfigurationUpdates_configurationUpdates_ResultConfigurationUpdates_resultConfigurationUpdates_RemoveOutputLocation = null;
            if (cmdletContext.ResultConfigurationUpdates_RemoveOutputLocation != null)
            {
                requestConfigurationUpdates_configurationUpdates_ResultConfigurationUpdates_resultConfigurationUpdates_RemoveOutputLocation = cmdletContext.ResultConfigurationUpdates_RemoveOutputLocation.Value;
            }
            if (requestConfigurationUpdates_configurationUpdates_ResultConfigurationUpdates_resultConfigurationUpdates_RemoveOutputLocation != null)
            {
                requestConfigurationUpdates_configurationUpdates_ResultConfigurationUpdates.RemoveOutputLocation = requestConfigurationUpdates_configurationUpdates_ResultConfigurationUpdates_resultConfigurationUpdates_RemoveOutputLocation.Value;
                requestConfigurationUpdates_configurationUpdates_ResultConfigurationUpdatesIsNull = false;
            }
            Amazon.Athena.Model.AclConfiguration requestConfigurationUpdates_configurationUpdates_ResultConfigurationUpdates_configurationUpdates_ResultConfigurationUpdates_AclConfiguration = null;
            
             // populate AclConfiguration
            var requestConfigurationUpdates_configurationUpdates_ResultConfigurationUpdates_configurationUpdates_ResultConfigurationUpdates_AclConfigurationIsNull = true;
            requestConfigurationUpdates_configurationUpdates_ResultConfigurationUpdates_configurationUpdates_ResultConfigurationUpdates_AclConfiguration = new Amazon.Athena.Model.AclConfiguration();
            Amazon.Athena.S3AclOption requestConfigurationUpdates_configurationUpdates_ResultConfigurationUpdates_configurationUpdates_ResultConfigurationUpdates_AclConfiguration_aclConfiguration_S3AclOption = null;
            if (cmdletContext.AclConfiguration_S3AclOption != null)
            {
                requestConfigurationUpdates_configurationUpdates_ResultConfigurationUpdates_configurationUpdates_ResultConfigurationUpdates_AclConfiguration_aclConfiguration_S3AclOption = cmdletContext.AclConfiguration_S3AclOption;
            }
            if (requestConfigurationUpdates_configurationUpdates_ResultConfigurationUpdates_configurationUpdates_ResultConfigurationUpdates_AclConfiguration_aclConfiguration_S3AclOption != null)
            {
                requestConfigurationUpdates_configurationUpdates_ResultConfigurationUpdates_configurationUpdates_ResultConfigurationUpdates_AclConfiguration.S3AclOption = requestConfigurationUpdates_configurationUpdates_ResultConfigurationUpdates_configurationUpdates_ResultConfigurationUpdates_AclConfiguration_aclConfiguration_S3AclOption;
                requestConfigurationUpdates_configurationUpdates_ResultConfigurationUpdates_configurationUpdates_ResultConfigurationUpdates_AclConfigurationIsNull = false;
            }
             // determine if requestConfigurationUpdates_configurationUpdates_ResultConfigurationUpdates_configurationUpdates_ResultConfigurationUpdates_AclConfiguration should be set to null
            if (requestConfigurationUpdates_configurationUpdates_ResultConfigurationUpdates_configurationUpdates_ResultConfigurationUpdates_AclConfigurationIsNull)
            {
                requestConfigurationUpdates_configurationUpdates_ResultConfigurationUpdates_configurationUpdates_ResultConfigurationUpdates_AclConfiguration = null;
            }
            if (requestConfigurationUpdates_configurationUpdates_ResultConfigurationUpdates_configurationUpdates_ResultConfigurationUpdates_AclConfiguration != null)
            {
                requestConfigurationUpdates_configurationUpdates_ResultConfigurationUpdates.AclConfiguration = requestConfigurationUpdates_configurationUpdates_ResultConfigurationUpdates_configurationUpdates_ResultConfigurationUpdates_AclConfiguration;
                requestConfigurationUpdates_configurationUpdates_ResultConfigurationUpdatesIsNull = false;
            }
            Amazon.Athena.Model.EncryptionConfiguration requestConfigurationUpdates_configurationUpdates_ResultConfigurationUpdates_configurationUpdates_ResultConfigurationUpdates_EncryptionConfiguration = null;
            
             // populate EncryptionConfiguration
            var requestConfigurationUpdates_configurationUpdates_ResultConfigurationUpdates_configurationUpdates_ResultConfigurationUpdates_EncryptionConfigurationIsNull = true;
            requestConfigurationUpdates_configurationUpdates_ResultConfigurationUpdates_configurationUpdates_ResultConfigurationUpdates_EncryptionConfiguration = new Amazon.Athena.Model.EncryptionConfiguration();
            Amazon.Athena.EncryptionOption requestConfigurationUpdates_configurationUpdates_ResultConfigurationUpdates_configurationUpdates_ResultConfigurationUpdates_EncryptionConfiguration_encryptionConfiguration_EncryptionOption = null;
            if (cmdletContext.EncryptionConfiguration_EncryptionOption != null)
            {
                requestConfigurationUpdates_configurationUpdates_ResultConfigurationUpdates_configurationUpdates_ResultConfigurationUpdates_EncryptionConfiguration_encryptionConfiguration_EncryptionOption = cmdletContext.EncryptionConfiguration_EncryptionOption;
            }
            if (requestConfigurationUpdates_configurationUpdates_ResultConfigurationUpdates_configurationUpdates_ResultConfigurationUpdates_EncryptionConfiguration_encryptionConfiguration_EncryptionOption != null)
            {
                requestConfigurationUpdates_configurationUpdates_ResultConfigurationUpdates_configurationUpdates_ResultConfigurationUpdates_EncryptionConfiguration.EncryptionOption = requestConfigurationUpdates_configurationUpdates_ResultConfigurationUpdates_configurationUpdates_ResultConfigurationUpdates_EncryptionConfiguration_encryptionConfiguration_EncryptionOption;
                requestConfigurationUpdates_configurationUpdates_ResultConfigurationUpdates_configurationUpdates_ResultConfigurationUpdates_EncryptionConfigurationIsNull = false;
            }
            System.String requestConfigurationUpdates_configurationUpdates_ResultConfigurationUpdates_configurationUpdates_ResultConfigurationUpdates_EncryptionConfiguration_encryptionConfiguration_KmsKey = null;
            if (cmdletContext.EncryptionConfiguration_KmsKey != null)
            {
                requestConfigurationUpdates_configurationUpdates_ResultConfigurationUpdates_configurationUpdates_ResultConfigurationUpdates_EncryptionConfiguration_encryptionConfiguration_KmsKey = cmdletContext.EncryptionConfiguration_KmsKey;
            }
            if (requestConfigurationUpdates_configurationUpdates_ResultConfigurationUpdates_configurationUpdates_ResultConfigurationUpdates_EncryptionConfiguration_encryptionConfiguration_KmsKey != null)
            {
                requestConfigurationUpdates_configurationUpdates_ResultConfigurationUpdates_configurationUpdates_ResultConfigurationUpdates_EncryptionConfiguration.KmsKey = requestConfigurationUpdates_configurationUpdates_ResultConfigurationUpdates_configurationUpdates_ResultConfigurationUpdates_EncryptionConfiguration_encryptionConfiguration_KmsKey;
                requestConfigurationUpdates_configurationUpdates_ResultConfigurationUpdates_configurationUpdates_ResultConfigurationUpdates_EncryptionConfigurationIsNull = false;
            }
             // determine if requestConfigurationUpdates_configurationUpdates_ResultConfigurationUpdates_configurationUpdates_ResultConfigurationUpdates_EncryptionConfiguration should be set to null
            if (requestConfigurationUpdates_configurationUpdates_ResultConfigurationUpdates_configurationUpdates_ResultConfigurationUpdates_EncryptionConfigurationIsNull)
            {
                requestConfigurationUpdates_configurationUpdates_ResultConfigurationUpdates_configurationUpdates_ResultConfigurationUpdates_EncryptionConfiguration = null;
            }
            if (requestConfigurationUpdates_configurationUpdates_ResultConfigurationUpdates_configurationUpdates_ResultConfigurationUpdates_EncryptionConfiguration != null)
            {
                requestConfigurationUpdates_configurationUpdates_ResultConfigurationUpdates.EncryptionConfiguration = requestConfigurationUpdates_configurationUpdates_ResultConfigurationUpdates_configurationUpdates_ResultConfigurationUpdates_EncryptionConfiguration;
                requestConfigurationUpdates_configurationUpdates_ResultConfigurationUpdatesIsNull = false;
            }
             // determine if requestConfigurationUpdates_configurationUpdates_ResultConfigurationUpdates should be set to null
            if (requestConfigurationUpdates_configurationUpdates_ResultConfigurationUpdatesIsNull)
            {
                requestConfigurationUpdates_configurationUpdates_ResultConfigurationUpdates = null;
            }
            if (requestConfigurationUpdates_configurationUpdates_ResultConfigurationUpdates != null)
            {
                request.ConfigurationUpdates.ResultConfigurationUpdates = requestConfigurationUpdates_configurationUpdates_ResultConfigurationUpdates;
                requestConfigurationUpdatesIsNull = false;
            }
             // determine if request.ConfigurationUpdates should be set to null
            if (requestConfigurationUpdatesIsNull)
            {
                request.ConfigurationUpdates = null;
            }
            if (cmdletContext.Description != null)
            {
                request.Description = cmdletContext.Description;
            }
            if (cmdletContext.State != null)
            {
                request.State = cmdletContext.State;
            }
            if (cmdletContext.WorkGroup != null)
            {
                request.WorkGroup = cmdletContext.WorkGroup;
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
        
        private Amazon.Athena.Model.UpdateWorkGroupResponse CallAWSServiceOperation(IAmazonAthena client, Amazon.Athena.Model.UpdateWorkGroupRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Athena", "UpdateWorkGroup");
            try
            {
                #if DESKTOP
                return client.UpdateWorkGroup(request);
                #elif CORECLR
                return client.UpdateWorkGroupAsync(request).GetAwaiter().GetResult();
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
            public System.String ConfigurationUpdates_AdditionalConfiguration { get; set; }
            public System.Int64? ConfigurationUpdates_BytesScannedCutoffPerQuery { get; set; }
            public System.String CustomerContentEncryptionConfiguration_KmsKey { get; set; }
            public System.Boolean? ConfigurationUpdates_EnableMinimumEncryptionConfiguration { get; set; }
            public System.Boolean? ConfigurationUpdates_EnforceWorkGroupConfiguration { get; set; }
            public System.String EngineVersion_EffectiveEngineVersion { get; set; }
            public System.String EngineVersion_SelectedEngineVersion { get; set; }
            public System.String ConfigurationUpdates_ExecutionRole { get; set; }
            public System.Boolean? ConfigurationUpdates_PublishCloudWatchMetricsEnabled { get; set; }
            public System.Boolean? ConfigurationUpdates_RemoveBytesScannedCutoffPerQuery { get; set; }
            public System.Boolean? ConfigurationUpdates_RemoveCustomerContentEncryptionConfiguration { get; set; }
            public System.Boolean? ConfigurationUpdates_RequesterPaysEnabled { get; set; }
            public Amazon.Athena.S3AclOption AclConfiguration_S3AclOption { get; set; }
            public Amazon.Athena.EncryptionOption EncryptionConfiguration_EncryptionOption { get; set; }
            public System.String EncryptionConfiguration_KmsKey { get; set; }
            public System.String ResultConfigurationUpdates_ExpectedBucketOwner { get; set; }
            public System.String ResultConfigurationUpdates_OutputLocation { get; set; }
            public System.Boolean? ResultConfigurationUpdates_RemoveAclConfiguration { get; set; }
            public System.Boolean? ResultConfigurationUpdates_RemoveEncryptionConfiguration { get; set; }
            public System.Boolean? ResultConfigurationUpdates_RemoveExpectedBucketOwner { get; set; }
            public System.Boolean? ResultConfigurationUpdates_RemoveOutputLocation { get; set; }
            public System.String Description { get; set; }
            public Amazon.Athena.WorkGroupState State { get; set; }
            public System.String WorkGroup { get; set; }
            public System.Func<Amazon.Athena.Model.UpdateWorkGroupResponse, UpdateATHWorkGroupCmdlet, object> Select { get; set; } =
                (response, cmdlet) => null;
        }
        
    }
}
