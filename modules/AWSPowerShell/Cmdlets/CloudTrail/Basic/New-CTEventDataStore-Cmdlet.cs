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
using Amazon.CloudTrail;
using Amazon.CloudTrail.Model;

namespace Amazon.PowerShell.Cmdlets.CT
{
    /// <summary>
    /// Creates a new event data store.
    /// </summary>
    [Cmdlet("New", "CTEventDataStore", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.CloudTrail.Model.CreateEventDataStoreResponse")]
    [AWSCmdlet("Calls the AWS CloudTrail CreateEventDataStore API operation.", Operation = new[] {"CreateEventDataStore"}, SelectReturnType = typeof(Amazon.CloudTrail.Model.CreateEventDataStoreResponse))]
    [AWSCmdletOutput("Amazon.CloudTrail.Model.CreateEventDataStoreResponse",
        "This cmdlet returns an Amazon.CloudTrail.Model.CreateEventDataStoreResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class NewCTEventDataStoreCmdlet : AmazonCloudTrailClientCmdlet, IExecutor
    {
        
        #region Parameter AdvancedEventSelector
        /// <summary>
        /// <para>
        /// <para>The advanced event selectors to use to select the events for the data store. For more
        /// information about how to use advanced event selectors, see <a href="https://docs.aws.amazon.com/awscloudtrail/latest/userguide/logging-data-events-with-cloudtrail.html#creating-data-event-selectors-advanced">Log
        /// events by using advanced event selectors</a> in the CloudTrail User Guide.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("AdvancedEventSelectors")]
        public Amazon.CloudTrail.Model.AdvancedEventSelector[] AdvancedEventSelector { get; set; }
        #endregion
        
        #region Parameter KmsKeyId
        /// <summary>
        /// <para>
        /// <para>Specifies the KMS key ID to use to encrypt the events delivered by CloudTrail. The
        /// value can be an alias name prefixed by <code>alias/</code>, a fully specified ARN
        /// to an alias, a fully specified ARN to a key, or a globally unique identifier.</para><important><para>Disabling or deleting the KMS key, or removing CloudTrail permissions on the key,
        /// prevents CloudTrail from logging events to the event data store, and prevents users
        /// from querying the data in the event data store that was encrypted with the key. After
        /// you associate an event data store with a KMS key, the KMS key cannot be removed or
        /// changed. Before you disable or delete a KMS key that you are using with an event data
        /// store, delete or back up your event data store.</para></important><para>CloudTrail also supports KMS multi-Region keys. For more information about multi-Region
        /// keys, see <a href="https://docs.aws.amazon.com/kms/latest/developerguide/multi-region-keys-overview.html">Using
        /// multi-Region keys</a> in the <i>Key Management Service Developer Guide</i>.</para><para>Examples:</para><ul><li><para><code>alias/MyAliasName</code></para></li><li><para><code>arn:aws:kms:us-east-2:123456789012:alias/MyAliasName</code></para></li><li><para><code>arn:aws:kms:us-east-2:123456789012:key/12345678-1234-1234-1234-123456789012</code></para></li><li><para><code>12345678-1234-1234-1234-123456789012</code></para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String KmsKeyId { get; set; }
        #endregion
        
        #region Parameter MultiRegionEnabled
        /// <summary>
        /// <para>
        /// <para>Specifies whether the event data store includes events from all regions, or only from
        /// the region in which the event data store is created.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? MultiRegionEnabled { get; set; }
        #endregion
        
        #region Parameter Name
        /// <summary>
        /// <para>
        /// <para>The name of the event data store.</para>
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
        
        #region Parameter OrganizationEnabled
        /// <summary>
        /// <para>
        /// <para>Specifies whether an event data store collects events logged for an organization in
        /// Organizations.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? OrganizationEnabled { get; set; }
        #endregion
        
        #region Parameter RetentionPeriod
        /// <summary>
        /// <para>
        /// <para>The retention period of the event data store, in days. You can set a retention period
        /// of up to 2557 days, the equivalent of seven years.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? RetentionPeriod { get; set; }
        #endregion
        
        #region Parameter TagsList
        /// <summary>
        /// <para>
        /// The service has not provided documentation for this parameter; please refer to the service's API reference documentation for the latest available information.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public Amazon.CloudTrail.Model.Tag[] TagsList { get; set; }
        #endregion
        
        #region Parameter TerminationProtectionEnabled
        /// <summary>
        /// <para>
        /// <para>Specifies whether termination protection is enabled for the event data store. If termination
        /// protection is enabled, you cannot delete the event data store until termination protection
        /// is disabled.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? TerminationProtectionEnabled { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.CloudTrail.Model.CreateEventDataStoreResponse).
        /// Specifying the name of a property of type Amazon.CloudTrail.Model.CreateEventDataStoreResponse will result in that property being returned.
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
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-CTEventDataStore (CreateEventDataStore)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.CloudTrail.Model.CreateEventDataStoreResponse, NewCTEventDataStoreCmdlet>(Select) ??
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
            if (this.AdvancedEventSelector != null)
            {
                context.AdvancedEventSelector = new List<Amazon.CloudTrail.Model.AdvancedEventSelector>(this.AdvancedEventSelector);
            }
            context.KmsKeyId = this.KmsKeyId;
            context.MultiRegionEnabled = this.MultiRegionEnabled;
            context.Name = this.Name;
            #if MODULAR
            if (this.Name == null && ParameterWasBound(nameof(this.Name)))
            {
                WriteWarning("You are passing $null as a value for parameter Name which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.OrganizationEnabled = this.OrganizationEnabled;
            context.RetentionPeriod = this.RetentionPeriod;
            if (this.TagsList != null)
            {
                context.TagsList = new List<Amazon.CloudTrail.Model.Tag>(this.TagsList);
            }
            context.TerminationProtectionEnabled = this.TerminationProtectionEnabled;
            
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
            var request = new Amazon.CloudTrail.Model.CreateEventDataStoreRequest();
            
            if (cmdletContext.AdvancedEventSelector != null)
            {
                request.AdvancedEventSelectors = cmdletContext.AdvancedEventSelector;
            }
            if (cmdletContext.KmsKeyId != null)
            {
                request.KmsKeyId = cmdletContext.KmsKeyId;
            }
            if (cmdletContext.MultiRegionEnabled != null)
            {
                request.MultiRegionEnabled = cmdletContext.MultiRegionEnabled.Value;
            }
            if (cmdletContext.Name != null)
            {
                request.Name = cmdletContext.Name;
            }
            if (cmdletContext.OrganizationEnabled != null)
            {
                request.OrganizationEnabled = cmdletContext.OrganizationEnabled.Value;
            }
            if (cmdletContext.RetentionPeriod != null)
            {
                request.RetentionPeriod = cmdletContext.RetentionPeriod.Value;
            }
            if (cmdletContext.TagsList != null)
            {
                request.TagsList = cmdletContext.TagsList;
            }
            if (cmdletContext.TerminationProtectionEnabled != null)
            {
                request.TerminationProtectionEnabled = cmdletContext.TerminationProtectionEnabled.Value;
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
        
        private Amazon.CloudTrail.Model.CreateEventDataStoreResponse CallAWSServiceOperation(IAmazonCloudTrail client, Amazon.CloudTrail.Model.CreateEventDataStoreRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS CloudTrail", "CreateEventDataStore");
            try
            {
                #if DESKTOP
                return client.CreateEventDataStore(request);
                #elif CORECLR
                return client.CreateEventDataStoreAsync(request).GetAwaiter().GetResult();
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
            public List<Amazon.CloudTrail.Model.AdvancedEventSelector> AdvancedEventSelector { get; set; }
            public System.String KmsKeyId { get; set; }
            public System.Boolean? MultiRegionEnabled { get; set; }
            public System.String Name { get; set; }
            public System.Boolean? OrganizationEnabled { get; set; }
            public System.Int32? RetentionPeriod { get; set; }
            public List<Amazon.CloudTrail.Model.Tag> TagsList { get; set; }
            public System.Boolean? TerminationProtectionEnabled { get; set; }
            public System.Func<Amazon.CloudTrail.Model.CreateEventDataStoreResponse, NewCTEventDataStoreCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
