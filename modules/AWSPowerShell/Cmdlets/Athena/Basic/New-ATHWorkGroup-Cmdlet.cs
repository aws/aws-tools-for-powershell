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
    /// Creates a workgroup with the specified name.
    /// </summary>
    [Cmdlet("New", "ATHWorkGroup", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("None")]
    [AWSCmdlet("Calls the Amazon Athena CreateWorkGroup API operation.", Operation = new[] {"CreateWorkGroup"}, SelectReturnType = typeof(Amazon.Athena.Model.CreateWorkGroupResponse))]
    [AWSCmdletOutput("None or Amazon.Athena.Model.CreateWorkGroupResponse",
        "This cmdlet does not generate any output." +
        "The service response (type Amazon.Athena.Model.CreateWorkGroupResponse) can be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class NewATHWorkGroupCmdlet : AmazonAthenaClientCmdlet, IExecutor
    {
        
        #region Parameter Configuration_BytesScannedCutoffPerQuery
        /// <summary>
        /// <para>
        /// <para>The upper data usage limit (cutoff) for the amount of bytes a single query in a workgroup
        /// is allowed to scan.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int64? Configuration_BytesScannedCutoffPerQuery { get; set; }
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
        
        #region Parameter EncryptionConfiguration_EncryptionOption
        /// <summary>
        /// <para>
        /// <para>Indicates whether Amazon S3 server-side encryption with Amazon S3-managed keys (<code>SSE-S3</code>),
        /// server-side encryption with KMS-managed keys (<code>SSE-KMS</code>), or client-side
        /// encryption with KMS-managed keys (CSE-KMS) is used.</para><para>If a query runs in a workgroup and the workgroup overrides client-side settings, then
        /// the workgroup's setting for encryption is used. It specifies whether query results
        /// must be encrypted, for all queries that run in this workgroup. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Configuration_ResultConfiguration_EncryptionConfiguration_EncryptionOption")]
        [AWSConstantClassSource("Amazon.Athena.EncryptionOption")]
        public Amazon.Athena.EncryptionOption EncryptionConfiguration_EncryptionOption { get; set; }
        #endregion
        
        #region Parameter Configuration_EnforceWorkGroupConfiguration
        /// <summary>
        /// <para>
        /// <para>If set to "true", the settings for the workgroup override client-side settings. If
        /// set to "false", client-side settings are used. For more information, see <a href="https://docs.aws.amazon.com/athena/latest/ug/workgroups-settings-override.html">Workgroup
        /// Settings Override Client-Side Settings</a>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? Configuration_EnforceWorkGroupConfiguration { get; set; }
        #endregion
        
        #region Parameter EncryptionConfiguration_KmsKey
        /// <summary>
        /// <para>
        /// <para>For <code>SSE-KMS</code> and <code>CSE-KMS</code>, this is the KMS key ARN or ID.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Configuration_ResultConfiguration_EncryptionConfiguration_KmsKey")]
        public System.String EncryptionConfiguration_KmsKey { get; set; }
        #endregion
        
        #region Parameter Name
        /// <summary>
        /// <para>
        /// <para>The workgroup name.</para>
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
        public System.String Name { get; set; }
        #endregion
        
        #region Parameter ResultConfiguration_OutputLocation
        /// <summary>
        /// <para>
        /// <para>The location in Amazon S3 where your query results are stored, such as <code>s3://path/to/query/bucket/</code>.
        /// To run the query, you must specify the query results location using one of the ways:
        /// either for individual queries using either this setting (client-side), or in the workgroup,
        /// using <a>WorkGroupConfiguration</a>. If none of them is set, Athena issues an error
        /// that no output location is provided. For more information, see <a href="https://docs.aws.amazon.com/athena/latest/ug/querying.html">Query
        /// Results</a>. If workgroup settings override client-side settings, then the query uses
        /// the settings specified for the workgroup. See <a>WorkGroupConfiguration$EnforceWorkGroupConfiguration</a>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Configuration_ResultConfiguration_OutputLocation")]
        public System.String ResultConfiguration_OutputLocation { get; set; }
        #endregion
        
        #region Parameter Configuration_PublishCloudWatchMetricsEnabled
        /// <summary>
        /// <para>
        /// <para>Indicates that the Amazon CloudWatch metrics are enabled for the workgroup.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? Configuration_PublishCloudWatchMetricsEnabled { get; set; }
        #endregion
        
        #region Parameter Configuration_RequesterPaysEnabled
        /// <summary>
        /// <para>
        /// <para>If set to <code>true</code>, allows members assigned to a workgroup to reference Amazon
        /// S3 Requester Pays buckets in queries. If set to <code>false</code>, workgroup members
        /// cannot query data from Requester Pays buckets, and queries that retrieve data from
        /// Requester Pays buckets cause an error. The default is <code>false</code>. For more
        /// information about Requester Pays buckets, see <a href="https://docs.aws.amazon.com/AmazonS3/latest/dev/RequesterPaysBuckets.html">Requester
        /// Pays Buckets</a> in the <i>Amazon Simple Storage Service Developer Guide</i>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? Configuration_RequesterPaysEnabled { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>One or more tags, separated by commas, that you want to attach to the workgroup as
        /// you create it.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public Amazon.Athena.Model.Tag[] Tag { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The cmdlet doesn't have a return value by default.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Athena.Model.CreateWorkGroupResponse).
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the Name parameter.
        /// The -PassThru parameter is deprecated, use -Select '^Name' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^Name' instead. This parameter will be removed in a future version.")]
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
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.Name), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-ATHWorkGroup (CreateWorkGroup)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Athena.Model.CreateWorkGroupResponse, NewATHWorkGroupCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.Name;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.Configuration_BytesScannedCutoffPerQuery = this.Configuration_BytesScannedCutoffPerQuery;
            context.Configuration_EnforceWorkGroupConfiguration = this.Configuration_EnforceWorkGroupConfiguration;
            context.Configuration_PublishCloudWatchMetricsEnabled = this.Configuration_PublishCloudWatchMetricsEnabled;
            context.Configuration_RequesterPaysEnabled = this.Configuration_RequesterPaysEnabled;
            context.EncryptionConfiguration_EncryptionOption = this.EncryptionConfiguration_EncryptionOption;
            context.EncryptionConfiguration_KmsKey = this.EncryptionConfiguration_KmsKey;
            context.ResultConfiguration_OutputLocation = this.ResultConfiguration_OutputLocation;
            context.Description = this.Description;
            context.Name = this.Name;
            #if MODULAR
            if (this.Name == null && ParameterWasBound(nameof(this.Name)))
            {
                WriteWarning("You are passing $null as a value for parameter Name which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.Tag != null)
            {
                context.Tag = new List<Amazon.Athena.Model.Tag>(this.Tag);
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
            var request = new Amazon.Athena.Model.CreateWorkGroupRequest();
            
            
             // populate Configuration
            var requestConfigurationIsNull = true;
            request.Configuration = new Amazon.Athena.Model.WorkGroupConfiguration();
            System.Int64? requestConfiguration_configuration_BytesScannedCutoffPerQuery = null;
            if (cmdletContext.Configuration_BytesScannedCutoffPerQuery != null)
            {
                requestConfiguration_configuration_BytesScannedCutoffPerQuery = cmdletContext.Configuration_BytesScannedCutoffPerQuery.Value;
            }
            if (requestConfiguration_configuration_BytesScannedCutoffPerQuery != null)
            {
                request.Configuration.BytesScannedCutoffPerQuery = requestConfiguration_configuration_BytesScannedCutoffPerQuery.Value;
                requestConfigurationIsNull = false;
            }
            System.Boolean? requestConfiguration_configuration_EnforceWorkGroupConfiguration = null;
            if (cmdletContext.Configuration_EnforceWorkGroupConfiguration != null)
            {
                requestConfiguration_configuration_EnforceWorkGroupConfiguration = cmdletContext.Configuration_EnforceWorkGroupConfiguration.Value;
            }
            if (requestConfiguration_configuration_EnforceWorkGroupConfiguration != null)
            {
                request.Configuration.EnforceWorkGroupConfiguration = requestConfiguration_configuration_EnforceWorkGroupConfiguration.Value;
                requestConfigurationIsNull = false;
            }
            System.Boolean? requestConfiguration_configuration_PublishCloudWatchMetricsEnabled = null;
            if (cmdletContext.Configuration_PublishCloudWatchMetricsEnabled != null)
            {
                requestConfiguration_configuration_PublishCloudWatchMetricsEnabled = cmdletContext.Configuration_PublishCloudWatchMetricsEnabled.Value;
            }
            if (requestConfiguration_configuration_PublishCloudWatchMetricsEnabled != null)
            {
                request.Configuration.PublishCloudWatchMetricsEnabled = requestConfiguration_configuration_PublishCloudWatchMetricsEnabled.Value;
                requestConfigurationIsNull = false;
            }
            System.Boolean? requestConfiguration_configuration_RequesterPaysEnabled = null;
            if (cmdletContext.Configuration_RequesterPaysEnabled != null)
            {
                requestConfiguration_configuration_RequesterPaysEnabled = cmdletContext.Configuration_RequesterPaysEnabled.Value;
            }
            if (requestConfiguration_configuration_RequesterPaysEnabled != null)
            {
                request.Configuration.RequesterPaysEnabled = requestConfiguration_configuration_RequesterPaysEnabled.Value;
                requestConfigurationIsNull = false;
            }
            Amazon.Athena.Model.ResultConfiguration requestConfiguration_configuration_ResultConfiguration = null;
            
             // populate ResultConfiguration
            var requestConfiguration_configuration_ResultConfigurationIsNull = true;
            requestConfiguration_configuration_ResultConfiguration = new Amazon.Athena.Model.ResultConfiguration();
            System.String requestConfiguration_configuration_ResultConfiguration_resultConfiguration_OutputLocation = null;
            if (cmdletContext.ResultConfiguration_OutputLocation != null)
            {
                requestConfiguration_configuration_ResultConfiguration_resultConfiguration_OutputLocation = cmdletContext.ResultConfiguration_OutputLocation;
            }
            if (requestConfiguration_configuration_ResultConfiguration_resultConfiguration_OutputLocation != null)
            {
                requestConfiguration_configuration_ResultConfiguration.OutputLocation = requestConfiguration_configuration_ResultConfiguration_resultConfiguration_OutputLocation;
                requestConfiguration_configuration_ResultConfigurationIsNull = false;
            }
            Amazon.Athena.Model.EncryptionConfiguration requestConfiguration_configuration_ResultConfiguration_configuration_ResultConfiguration_EncryptionConfiguration = null;
            
             // populate EncryptionConfiguration
            var requestConfiguration_configuration_ResultConfiguration_configuration_ResultConfiguration_EncryptionConfigurationIsNull = true;
            requestConfiguration_configuration_ResultConfiguration_configuration_ResultConfiguration_EncryptionConfiguration = new Amazon.Athena.Model.EncryptionConfiguration();
            Amazon.Athena.EncryptionOption requestConfiguration_configuration_ResultConfiguration_configuration_ResultConfiguration_EncryptionConfiguration_encryptionConfiguration_EncryptionOption = null;
            if (cmdletContext.EncryptionConfiguration_EncryptionOption != null)
            {
                requestConfiguration_configuration_ResultConfiguration_configuration_ResultConfiguration_EncryptionConfiguration_encryptionConfiguration_EncryptionOption = cmdletContext.EncryptionConfiguration_EncryptionOption;
            }
            if (requestConfiguration_configuration_ResultConfiguration_configuration_ResultConfiguration_EncryptionConfiguration_encryptionConfiguration_EncryptionOption != null)
            {
                requestConfiguration_configuration_ResultConfiguration_configuration_ResultConfiguration_EncryptionConfiguration.EncryptionOption = requestConfiguration_configuration_ResultConfiguration_configuration_ResultConfiguration_EncryptionConfiguration_encryptionConfiguration_EncryptionOption;
                requestConfiguration_configuration_ResultConfiguration_configuration_ResultConfiguration_EncryptionConfigurationIsNull = false;
            }
            System.String requestConfiguration_configuration_ResultConfiguration_configuration_ResultConfiguration_EncryptionConfiguration_encryptionConfiguration_KmsKey = null;
            if (cmdletContext.EncryptionConfiguration_KmsKey != null)
            {
                requestConfiguration_configuration_ResultConfiguration_configuration_ResultConfiguration_EncryptionConfiguration_encryptionConfiguration_KmsKey = cmdletContext.EncryptionConfiguration_KmsKey;
            }
            if (requestConfiguration_configuration_ResultConfiguration_configuration_ResultConfiguration_EncryptionConfiguration_encryptionConfiguration_KmsKey != null)
            {
                requestConfiguration_configuration_ResultConfiguration_configuration_ResultConfiguration_EncryptionConfiguration.KmsKey = requestConfiguration_configuration_ResultConfiguration_configuration_ResultConfiguration_EncryptionConfiguration_encryptionConfiguration_KmsKey;
                requestConfiguration_configuration_ResultConfiguration_configuration_ResultConfiguration_EncryptionConfigurationIsNull = false;
            }
             // determine if requestConfiguration_configuration_ResultConfiguration_configuration_ResultConfiguration_EncryptionConfiguration should be set to null
            if (requestConfiguration_configuration_ResultConfiguration_configuration_ResultConfiguration_EncryptionConfigurationIsNull)
            {
                requestConfiguration_configuration_ResultConfiguration_configuration_ResultConfiguration_EncryptionConfiguration = null;
            }
            if (requestConfiguration_configuration_ResultConfiguration_configuration_ResultConfiguration_EncryptionConfiguration != null)
            {
                requestConfiguration_configuration_ResultConfiguration.EncryptionConfiguration = requestConfiguration_configuration_ResultConfiguration_configuration_ResultConfiguration_EncryptionConfiguration;
                requestConfiguration_configuration_ResultConfigurationIsNull = false;
            }
             // determine if requestConfiguration_configuration_ResultConfiguration should be set to null
            if (requestConfiguration_configuration_ResultConfigurationIsNull)
            {
                requestConfiguration_configuration_ResultConfiguration = null;
            }
            if (requestConfiguration_configuration_ResultConfiguration != null)
            {
                request.Configuration.ResultConfiguration = requestConfiguration_configuration_ResultConfiguration;
                requestConfigurationIsNull = false;
            }
             // determine if request.Configuration should be set to null
            if (requestConfigurationIsNull)
            {
                request.Configuration = null;
            }
            if (cmdletContext.Description != null)
            {
                request.Description = cmdletContext.Description;
            }
            if (cmdletContext.Name != null)
            {
                request.Name = cmdletContext.Name;
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
        
        private Amazon.Athena.Model.CreateWorkGroupResponse CallAWSServiceOperation(IAmazonAthena client, Amazon.Athena.Model.CreateWorkGroupRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Athena", "CreateWorkGroup");
            try
            {
                #if DESKTOP
                return client.CreateWorkGroup(request);
                #elif CORECLR
                return client.CreateWorkGroupAsync(request).GetAwaiter().GetResult();
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
            public System.Int64? Configuration_BytesScannedCutoffPerQuery { get; set; }
            public System.Boolean? Configuration_EnforceWorkGroupConfiguration { get; set; }
            public System.Boolean? Configuration_PublishCloudWatchMetricsEnabled { get; set; }
            public System.Boolean? Configuration_RequesterPaysEnabled { get; set; }
            public Amazon.Athena.EncryptionOption EncryptionConfiguration_EncryptionOption { get; set; }
            public System.String EncryptionConfiguration_KmsKey { get; set; }
            public System.String ResultConfiguration_OutputLocation { get; set; }
            public System.String Description { get; set; }
            public System.String Name { get; set; }
            public List<Amazon.Athena.Model.Tag> Tag { get; set; }
            public System.Func<Amazon.Athena.Model.CreateWorkGroupResponse, NewATHWorkGroupCmdlet, object> Select { get; set; } =
                (response, cmdlet) => null;
        }
        
    }
}
