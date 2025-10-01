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
using Amazon.PCS;
using Amazon.PCS.Model;

namespace Amazon.PowerShell.Cmdlets.PCS
{
    /// <summary>
    /// Creates a job queue. You must associate 1 or more compute node groups with the queue.
    /// You can associate 1 compute node group with multiple queues.
    /// </summary>
    [Cmdlet("New", "PCSQueue", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.PCS.Model.Queue")]
    [AWSCmdlet("Calls the AWS Parallel Computing Service CreateQueue API operation.", Operation = new[] {"CreateQueue"}, SelectReturnType = typeof(Amazon.PCS.Model.CreateQueueResponse))]
    [AWSCmdletOutput("Amazon.PCS.Model.Queue or Amazon.PCS.Model.CreateQueueResponse",
        "This cmdlet returns an Amazon.PCS.Model.Queue object.",
        "The service call response (type Amazon.PCS.Model.CreateQueueResponse) can be returned by specifying '-Select *'."
    )]
    public partial class NewPCSQueueCmdlet : AmazonPCSClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter ClusterIdentifier
        /// <summary>
        /// <para>
        /// <para>The name or ID of the cluster for which to create a queue.</para>
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
        public System.String ClusterIdentifier { get; set; }
        #endregion
        
        #region Parameter ComputeNodeGroupConfiguration
        /// <summary>
        /// <para>
        /// <para>The list of compute node group configurations to associate with the queue. Queues
        /// assign jobs to associated compute node groups.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ComputeNodeGroupConfigurations")]
        public Amazon.PCS.Model.ComputeNodeGroupConfiguration[] ComputeNodeGroupConfiguration { get; set; }
        #endregion
        
        #region Parameter QueueName
        /// <summary>
        /// <para>
        /// <para>A name to identify the queue.</para>
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
        public System.String QueueName { get; set; }
        #endregion
        
        #region Parameter SlurmConfiguration_SlurmCustomSetting
        /// <summary>
        /// <para>
        /// <para>Additional Slurm-specific configuration that directly maps to Slurm settings.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("SlurmConfiguration_SlurmCustomSettings")]
        public Amazon.PCS.Model.SlurmCustomSetting[] SlurmConfiguration_SlurmCustomSetting { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>1 or more tags added to the resource. Each tag consists of a tag key and tag value.
        /// The tag value is optional and can be an empty string.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public System.Collections.Hashtable Tag { get; set; }
        #endregion
        
        #region Parameter ClientToken
        /// <summary>
        /// <para>
        /// <para>A unique, case-sensitive identifier that you provide to ensure the idempotency of
        /// the request. Idempotency ensures that an API request completes only once. With an
        /// idempotent request, if the original request completes successfully, the subsequent
        /// retries with the same client token return the result from the original successful
        /// request and they have no additional effect. If you don't specify a client token, the
        /// CLI and SDK automatically generate 1 for you.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ClientToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'Queue'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.PCS.Model.CreateQueueResponse).
        /// Specifying the name of a property of type Amazon.PCS.Model.CreateQueueResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "Queue";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the QueueName parameter.
        /// The -PassThru parameter is deprecated, use -Select '^QueueName' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^QueueName' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.QueueName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-PCSQueue (CreateQueue)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.PCS.Model.CreateQueueResponse, NewPCSQueueCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.QueueName;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.ClientToken = this.ClientToken;
            context.ClusterIdentifier = this.ClusterIdentifier;
            #if MODULAR
            if (this.ClusterIdentifier == null && ParameterWasBound(nameof(this.ClusterIdentifier)))
            {
                WriteWarning("You are passing $null as a value for parameter ClusterIdentifier which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.ComputeNodeGroupConfiguration != null)
            {
                context.ComputeNodeGroupConfiguration = new List<Amazon.PCS.Model.ComputeNodeGroupConfiguration>(this.ComputeNodeGroupConfiguration);
            }
            context.QueueName = this.QueueName;
            #if MODULAR
            if (this.QueueName == null && ParameterWasBound(nameof(this.QueueName)))
            {
                WriteWarning("You are passing $null as a value for parameter QueueName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.SlurmConfiguration_SlurmCustomSetting != null)
            {
                context.SlurmConfiguration_SlurmCustomSetting = new List<Amazon.PCS.Model.SlurmCustomSetting>(this.SlurmConfiguration_SlurmCustomSetting);
            }
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
            var request = new Amazon.PCS.Model.CreateQueueRequest();
            
            if (cmdletContext.ClientToken != null)
            {
                request.ClientToken = cmdletContext.ClientToken;
            }
            if (cmdletContext.ClusterIdentifier != null)
            {
                request.ClusterIdentifier = cmdletContext.ClusterIdentifier;
            }
            if (cmdletContext.ComputeNodeGroupConfiguration != null)
            {
                request.ComputeNodeGroupConfigurations = cmdletContext.ComputeNodeGroupConfiguration;
            }
            if (cmdletContext.QueueName != null)
            {
                request.QueueName = cmdletContext.QueueName;
            }
            
             // populate SlurmConfiguration
            var requestSlurmConfigurationIsNull = true;
            request.SlurmConfiguration = new Amazon.PCS.Model.QueueSlurmConfigurationRequest();
            List<Amazon.PCS.Model.SlurmCustomSetting> requestSlurmConfiguration_slurmConfiguration_SlurmCustomSetting = null;
            if (cmdletContext.SlurmConfiguration_SlurmCustomSetting != null)
            {
                requestSlurmConfiguration_slurmConfiguration_SlurmCustomSetting = cmdletContext.SlurmConfiguration_SlurmCustomSetting;
            }
            if (requestSlurmConfiguration_slurmConfiguration_SlurmCustomSetting != null)
            {
                request.SlurmConfiguration.SlurmCustomSettings = requestSlurmConfiguration_slurmConfiguration_SlurmCustomSetting;
                requestSlurmConfigurationIsNull = false;
            }
             // determine if request.SlurmConfiguration should be set to null
            if (requestSlurmConfigurationIsNull)
            {
                request.SlurmConfiguration = null;
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
        
        private Amazon.PCS.Model.CreateQueueResponse CallAWSServiceOperation(IAmazonPCS client, Amazon.PCS.Model.CreateQueueRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Parallel Computing Service", "CreateQueue");
            try
            {
                #if DESKTOP
                return client.CreateQueue(request);
                #elif CORECLR
                return client.CreateQueueAsync(request).GetAwaiter().GetResult();
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
            public System.String ClientToken { get; set; }
            public System.String ClusterIdentifier { get; set; }
            public List<Amazon.PCS.Model.ComputeNodeGroupConfiguration> ComputeNodeGroupConfiguration { get; set; }
            public System.String QueueName { get; set; }
            public List<Amazon.PCS.Model.SlurmCustomSetting> SlurmConfiguration_SlurmCustomSetting { get; set; }
            public Dictionary<System.String, System.String> Tag { get; set; }
            public System.Func<Amazon.PCS.Model.CreateQueueResponse, NewPCSQueueCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.Queue;
        }
        
    }
}
