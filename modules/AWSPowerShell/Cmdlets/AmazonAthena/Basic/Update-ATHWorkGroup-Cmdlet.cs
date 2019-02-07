/*******************************************************************************
 *  Copyright 2012-2018 Amazon.com, Inc. or its affiliates. All Rights Reserved.
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
    /// </summary>
    [Cmdlet("Update", "ATHWorkGroup", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("None","System.String")]
    [AWSCmdlet("Calls the Amazon Athena UpdateWorkGroup API operation.", Operation = new[] {"UpdateWorkGroup"})]
    [AWSCmdletOutput("None or System.String",
        "When you use the PassThru parameter, this cmdlet outputs the value supplied to the WorkGroup parameter. Otherwise, this cmdlet does not return any output. " +
        "The service response (type Amazon.Athena.Model.UpdateWorkGroupResponse) can be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class UpdateATHWorkGroupCmdlet : AmazonAthenaClientCmdlet, IExecutor
    {
        
        #region Parameter ConfigurationUpdates_BytesScannedCutoffPerQuery
        /// <summary>
        /// <para>
        /// <para>The upper limit (cutoff) for the amount of bytes a single query in a workgroup is
        /// allowed to scan.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.Int64 ConfigurationUpdates_BytesScannedCutoffPerQuery { get; set; }
        #endregion
        
        #region Parameter Description
        /// <summary>
        /// <para>
        /// <para>The workgroup description.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
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
        [System.Management.Automation.Parameter]
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
        [System.Management.Automation.Parameter]
        public System.Boolean ConfigurationUpdates_EnforceWorkGroupConfiguration { get; set; }
        #endregion
        
        #region Parameter EncryptionConfiguration_KmsKey
        /// <summary>
        /// <para>
        /// <para>For <code>SSE-KMS</code> and <code>CSE-KMS</code>, this is the KMS key ARN or ID.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("ConfigurationUpdates_ResultConfigurationUpdates_EncryptionConfiguration_KmsKey")]
        public System.String EncryptionConfiguration_KmsKey { get; set; }
        #endregion
        
        #region Parameter ResultConfigurationUpdates_OutputLocation
        /// <summary>
        /// <para>
        /// <para>The location in Amazon S3 where your query results are stored, such as <code>s3://path/to/query/bucket/</code>.
        /// For more information, see <a href="https://docs.aws.amazon.com/athena/latest/ug/querying.html">Queries
        /// and Query Result Files.</a> If workgroup settings override client-side settings, then
        /// the query uses the location for the query results and the encryption configuration
        /// that are specified for the workgroup. The "workgroup settings override" is specified
        /// in EnforceWorkGroupConfiguration (true/false) in the WorkGroupConfiguration. See <a>WorkGroupConfiguration$EnforceWorkGroupConfiguration</a>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("ConfigurationUpdates_ResultConfigurationUpdates_OutputLocation")]
        public System.String ResultConfigurationUpdates_OutputLocation { get; set; }
        #endregion
        
        #region Parameter ConfigurationUpdates_PublishCloudWatchMetricsEnabled
        /// <summary>
        /// <para>
        /// <para>Indicates whether this workgroup enables publishing metrics to Amazon CloudWatch.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.Boolean ConfigurationUpdates_PublishCloudWatchMetricsEnabled { get; set; }
        #endregion
        
        #region Parameter ConfigurationUpdates_RemoveBytesScannedCutoffPerQuery
        /// <summary>
        /// <para>
        /// <para>Indicates that the data usage control limit per query is removed. <a>WorkGroupConfiguration$BytesScannedCutoffPerQuery</a></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.Boolean ConfigurationUpdates_RemoveBytesScannedCutoffPerQuery { get; set; }
        #endregion
        
        #region Parameter ResultConfigurationUpdates_RemoveEncryptionConfiguration
        /// <summary>
        /// <para>
        /// <para>If set to "true", indicates that the previously-specified encryption configuration
        /// (also known as the client-side setting) for queries in this workgroup should be ignored
        /// and set to null. If set to "false" or not set, and a value is present in the EncryptionConfiguration
        /// in ResultConfigurationUpdates (the client-side setting), the EncryptionConfiguration
        /// in the workgroup's ResultConfiguration will be updated with the new value. For more
        /// information, see <a href="https://docs.aws.amazon.com/athena/latest/ug/workgroups-settings-override.html">Workgroup
        /// Settings Override Client-Side Settings</a>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("ConfigurationUpdates_ResultConfigurationUpdates_RemoveEncryptionConfiguration")]
        public System.Boolean ResultConfigurationUpdates_RemoveEncryptionConfiguration { get; set; }
        #endregion
        
        #region Parameter ResultConfigurationUpdates_RemoveOutputLocation
        /// <summary>
        /// <para>
        /// <para>If set to "true", indicates that the previously-specified query results location (also
        /// known as a client-side setting) for queries in this workgroup should be ignored and
        /// set to null. If set to "false" or not set, and a value is present in the OutputLocation
        /// in ResultConfigurationUpdates (the client-side setting), the OutputLocation in the
        /// workgroup's ResultConfiguration will be updated with the new value. For more information,
        /// see <a href="https://docs.aws.amazon.com/athena/latest/ug/workgroups-settings-override.html">Workgroup
        /// Settings Override Client-Side Settings</a>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("ConfigurationUpdates_ResultConfigurationUpdates_RemoveOutputLocation")]
        public System.Boolean ResultConfigurationUpdates_RemoveOutputLocation { get; set; }
        #endregion
        
        #region Parameter State
        /// <summary>
        /// <para>
        /// <para>The workgroup state that will be updated for the given workgroup.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [AWSConstantClassSource("Amazon.Athena.WorkGroupState")]
        public Amazon.Athena.WorkGroupState State { get; set; }
        #endregion
        
        #region Parameter WorkGroup
        /// <summary>
        /// <para>
        /// <para>The specified workgroup that will be updated.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipeline = true)]
        public System.String WorkGroup { get; set; }
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Returns the value passed to the WorkGroup parameter.
        /// By default, this cmdlet does not generate any output.
        /// </summary>
        [System.Management.Automation.Parameter]
        public SwitchParameter PassThru { get; set; }
        #endregion
        
        #region Parameter Force
        /// <summary>
        /// This parameter overrides confirmation prompts to force 
        /// the cmdlet to continue its operation. This parameter should always
        /// be used with caution.
        /// </summary>
        [System.Management.Automation.Parameter]
        public SwitchParameter Force { get; set; }
        #endregion
        
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg("WorkGroup", MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-ATHWorkGroup (UpdateWorkGroup)"))
            {
                return;
            }
            
            var context = new CmdletContext
            {
                Region = this.Region,
                Credentials = this.CurrentCredentials
            };
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound("ConfigurationUpdates_BytesScannedCutoffPerQuery"))
                context.ConfigurationUpdates_BytesScannedCutoffPerQuery = this.ConfigurationUpdates_BytesScannedCutoffPerQuery;
            if (ParameterWasBound("ConfigurationUpdates_EnforceWorkGroupConfiguration"))
                context.ConfigurationUpdates_EnforceWorkGroupConfiguration = this.ConfigurationUpdates_EnforceWorkGroupConfiguration;
            if (ParameterWasBound("ConfigurationUpdates_PublishCloudWatchMetricsEnabled"))
                context.ConfigurationUpdates_PublishCloudWatchMetricsEnabled = this.ConfigurationUpdates_PublishCloudWatchMetricsEnabled;
            if (ParameterWasBound("ConfigurationUpdates_RemoveBytesScannedCutoffPerQuery"))
                context.ConfigurationUpdates_RemoveBytesScannedCutoffPerQuery = this.ConfigurationUpdates_RemoveBytesScannedCutoffPerQuery;
            context.ConfigurationUpdates_ResultConfigurationUpdates_EncryptionConfiguration_EncryptionOption = this.EncryptionConfiguration_EncryptionOption;
            context.ConfigurationUpdates_ResultConfigurationUpdates_EncryptionConfiguration_KmsKey = this.EncryptionConfiguration_KmsKey;
            context.ConfigurationUpdates_ResultConfigurationUpdates_OutputLocation = this.ResultConfigurationUpdates_OutputLocation;
            if (ParameterWasBound("ResultConfigurationUpdates_RemoveEncryptionConfiguration"))
                context.ConfigurationUpdates_ResultConfigurationUpdates_RemoveEncryptionConfiguration = this.ResultConfigurationUpdates_RemoveEncryptionConfiguration;
            if (ParameterWasBound("ResultConfigurationUpdates_RemoveOutputLocation"))
                context.ConfigurationUpdates_ResultConfigurationUpdates_RemoveOutputLocation = this.ResultConfigurationUpdates_RemoveOutputLocation;
            context.Description = this.Description;
            context.State = this.State;
            context.WorkGroup = this.WorkGroup;
            
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
            bool requestConfigurationUpdatesIsNull = true;
            request.ConfigurationUpdates = new Amazon.Athena.Model.WorkGroupConfigurationUpdates();
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
            Amazon.Athena.Model.ResultConfigurationUpdates requestConfigurationUpdates_configurationUpdates_ResultConfigurationUpdates = null;
            
             // populate ResultConfigurationUpdates
            bool requestConfigurationUpdates_configurationUpdates_ResultConfigurationUpdatesIsNull = true;
            requestConfigurationUpdates_configurationUpdates_ResultConfigurationUpdates = new Amazon.Athena.Model.ResultConfigurationUpdates();
            System.String requestConfigurationUpdates_configurationUpdates_ResultConfigurationUpdates_resultConfigurationUpdates_OutputLocation = null;
            if (cmdletContext.ConfigurationUpdates_ResultConfigurationUpdates_OutputLocation != null)
            {
                requestConfigurationUpdates_configurationUpdates_ResultConfigurationUpdates_resultConfigurationUpdates_OutputLocation = cmdletContext.ConfigurationUpdates_ResultConfigurationUpdates_OutputLocation;
            }
            if (requestConfigurationUpdates_configurationUpdates_ResultConfigurationUpdates_resultConfigurationUpdates_OutputLocation != null)
            {
                requestConfigurationUpdates_configurationUpdates_ResultConfigurationUpdates.OutputLocation = requestConfigurationUpdates_configurationUpdates_ResultConfigurationUpdates_resultConfigurationUpdates_OutputLocation;
                requestConfigurationUpdates_configurationUpdates_ResultConfigurationUpdatesIsNull = false;
            }
            System.Boolean? requestConfigurationUpdates_configurationUpdates_ResultConfigurationUpdates_resultConfigurationUpdates_RemoveEncryptionConfiguration = null;
            if (cmdletContext.ConfigurationUpdates_ResultConfigurationUpdates_RemoveEncryptionConfiguration != null)
            {
                requestConfigurationUpdates_configurationUpdates_ResultConfigurationUpdates_resultConfigurationUpdates_RemoveEncryptionConfiguration = cmdletContext.ConfigurationUpdates_ResultConfigurationUpdates_RemoveEncryptionConfiguration.Value;
            }
            if (requestConfigurationUpdates_configurationUpdates_ResultConfigurationUpdates_resultConfigurationUpdates_RemoveEncryptionConfiguration != null)
            {
                requestConfigurationUpdates_configurationUpdates_ResultConfigurationUpdates.RemoveEncryptionConfiguration = requestConfigurationUpdates_configurationUpdates_ResultConfigurationUpdates_resultConfigurationUpdates_RemoveEncryptionConfiguration.Value;
                requestConfigurationUpdates_configurationUpdates_ResultConfigurationUpdatesIsNull = false;
            }
            System.Boolean? requestConfigurationUpdates_configurationUpdates_ResultConfigurationUpdates_resultConfigurationUpdates_RemoveOutputLocation = null;
            if (cmdletContext.ConfigurationUpdates_ResultConfigurationUpdates_RemoveOutputLocation != null)
            {
                requestConfigurationUpdates_configurationUpdates_ResultConfigurationUpdates_resultConfigurationUpdates_RemoveOutputLocation = cmdletContext.ConfigurationUpdates_ResultConfigurationUpdates_RemoveOutputLocation.Value;
            }
            if (requestConfigurationUpdates_configurationUpdates_ResultConfigurationUpdates_resultConfigurationUpdates_RemoveOutputLocation != null)
            {
                requestConfigurationUpdates_configurationUpdates_ResultConfigurationUpdates.RemoveOutputLocation = requestConfigurationUpdates_configurationUpdates_ResultConfigurationUpdates_resultConfigurationUpdates_RemoveOutputLocation.Value;
                requestConfigurationUpdates_configurationUpdates_ResultConfigurationUpdatesIsNull = false;
            }
            Amazon.Athena.Model.EncryptionConfiguration requestConfigurationUpdates_configurationUpdates_ResultConfigurationUpdates_configurationUpdates_ResultConfigurationUpdates_EncryptionConfiguration = null;
            
             // populate EncryptionConfiguration
            bool requestConfigurationUpdates_configurationUpdates_ResultConfigurationUpdates_configurationUpdates_ResultConfigurationUpdates_EncryptionConfigurationIsNull = true;
            requestConfigurationUpdates_configurationUpdates_ResultConfigurationUpdates_configurationUpdates_ResultConfigurationUpdates_EncryptionConfiguration = new Amazon.Athena.Model.EncryptionConfiguration();
            Amazon.Athena.EncryptionOption requestConfigurationUpdates_configurationUpdates_ResultConfigurationUpdates_configurationUpdates_ResultConfigurationUpdates_EncryptionConfiguration_encryptionConfiguration_EncryptionOption = null;
            if (cmdletContext.ConfigurationUpdates_ResultConfigurationUpdates_EncryptionConfiguration_EncryptionOption != null)
            {
                requestConfigurationUpdates_configurationUpdates_ResultConfigurationUpdates_configurationUpdates_ResultConfigurationUpdates_EncryptionConfiguration_encryptionConfiguration_EncryptionOption = cmdletContext.ConfigurationUpdates_ResultConfigurationUpdates_EncryptionConfiguration_EncryptionOption;
            }
            if (requestConfigurationUpdates_configurationUpdates_ResultConfigurationUpdates_configurationUpdates_ResultConfigurationUpdates_EncryptionConfiguration_encryptionConfiguration_EncryptionOption != null)
            {
                requestConfigurationUpdates_configurationUpdates_ResultConfigurationUpdates_configurationUpdates_ResultConfigurationUpdates_EncryptionConfiguration.EncryptionOption = requestConfigurationUpdates_configurationUpdates_ResultConfigurationUpdates_configurationUpdates_ResultConfigurationUpdates_EncryptionConfiguration_encryptionConfiguration_EncryptionOption;
                requestConfigurationUpdates_configurationUpdates_ResultConfigurationUpdates_configurationUpdates_ResultConfigurationUpdates_EncryptionConfigurationIsNull = false;
            }
            System.String requestConfigurationUpdates_configurationUpdates_ResultConfigurationUpdates_configurationUpdates_ResultConfigurationUpdates_EncryptionConfiguration_encryptionConfiguration_KmsKey = null;
            if (cmdletContext.ConfigurationUpdates_ResultConfigurationUpdates_EncryptionConfiguration_KmsKey != null)
            {
                requestConfigurationUpdates_configurationUpdates_ResultConfigurationUpdates_configurationUpdates_ResultConfigurationUpdates_EncryptionConfiguration_encryptionConfiguration_KmsKey = cmdletContext.ConfigurationUpdates_ResultConfigurationUpdates_EncryptionConfiguration_KmsKey;
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
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = CallAWSServiceOperation(client, request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = null;
                if (this.PassThru.IsPresent)
                    pipelineOutput = this.WorkGroup;
                output = new CmdletOutput
                {
                    PipelineOutput = pipelineOutput,
                    ServiceResponse = response,
                    Notes = notes
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
                // todo: handle AggregateException and extract true service exception for rethrow
                var task = client.UpdateWorkGroupAsync(request);
                return task.Result;
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
            public System.Int64? ConfigurationUpdates_BytesScannedCutoffPerQuery { get; set; }
            public System.Boolean? ConfigurationUpdates_EnforceWorkGroupConfiguration { get; set; }
            public System.Boolean? ConfigurationUpdates_PublishCloudWatchMetricsEnabled { get; set; }
            public System.Boolean? ConfigurationUpdates_RemoveBytesScannedCutoffPerQuery { get; set; }
            public Amazon.Athena.EncryptionOption ConfigurationUpdates_ResultConfigurationUpdates_EncryptionConfiguration_EncryptionOption { get; set; }
            public System.String ConfigurationUpdates_ResultConfigurationUpdates_EncryptionConfiguration_KmsKey { get; set; }
            public System.String ConfigurationUpdates_ResultConfigurationUpdates_OutputLocation { get; set; }
            public System.Boolean? ConfigurationUpdates_ResultConfigurationUpdates_RemoveEncryptionConfiguration { get; set; }
            public System.Boolean? ConfigurationUpdates_ResultConfigurationUpdates_RemoveOutputLocation { get; set; }
            public System.String Description { get; set; }
            public Amazon.Athena.WorkGroupState State { get; set; }
            public System.String WorkGroup { get; set; }
        }
        
    }
}
