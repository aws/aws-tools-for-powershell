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
using Amazon.ElastiCache;
using Amazon.ElastiCache.Model;

namespace Amazon.PowerShell.Cmdlets.EC
{
    /// <summary>
    /// Global Datastore for Redis OSS offers fully managed, fast, reliable and secure cross-region
    /// replication. Using Global Datastore for Redis OSS, you can create cross-region read
    /// replica clusters for ElastiCache (Redis OSS) to enable low-latency reads and disaster
    /// recovery across regions. For more information, see <a href="https://docs.aws.amazon.com/AmazonElastiCache/latest/red-ug/Redis-Global-Datastore.html">Replication
    /// Across Regions Using Global Datastore</a>. 
    /// 
    ///  <ul><li><para>
    /// The <b>GlobalReplicationGroupIdSuffix</b> is the name of the Global datastore.
    /// </para></li><li><para>
    /// The <b>PrimaryReplicationGroupId</b> represents the name of the primary cluster that
    /// accepts writes and will replicate updates to the secondary cluster.
    /// </para></li></ul>
    /// </summary>
    [Cmdlet("New", "ECGlobalReplicationGroup", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.ElastiCache.Model.GlobalReplicationGroup")]
    [AWSCmdlet("Calls the Amazon ElastiCache CreateGlobalReplicationGroup API operation.", Operation = new[] {"CreateGlobalReplicationGroup"}, SelectReturnType = typeof(Amazon.ElastiCache.Model.CreateGlobalReplicationGroupResponse))]
    [AWSCmdletOutput("Amazon.ElastiCache.Model.GlobalReplicationGroup or Amazon.ElastiCache.Model.CreateGlobalReplicationGroupResponse",
        "This cmdlet returns an Amazon.ElastiCache.Model.GlobalReplicationGroup object.",
        "The service call response (type Amazon.ElastiCache.Model.CreateGlobalReplicationGroupResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class NewECGlobalReplicationGroupCmdlet : AmazonElastiCacheClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter GlobalReplicationGroupDescription
        /// <summary>
        /// <para>
        /// <para>Provides details of the Global datastore</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String GlobalReplicationGroupDescription { get; set; }
        #endregion
        
        #region Parameter GlobalReplicationGroupIdSuffix
        /// <summary>
        /// <para>
        /// <para>The suffix name of a Global datastore. Amazon ElastiCache automatically applies a
        /// prefix to the Global datastore ID when it is created. Each Amazon Region has its own
        /// prefix. For instance, a Global datastore ID created in the US-West-1 region will begin
        /// with "dsdfu" along with the suffix name you provide. The suffix, combined with the
        /// auto-generated prefix, guarantees uniqueness of the Global datastore name across multiple
        /// regions. </para><para>For a full list of Amazon Regions and their respective Global datastore iD prefixes,
        /// see <a href="http://docs.aws.amazon.com/AmazonElastiCache/latest/red-ug/Redis-Global-Datastores-CLI.html">Using
        /// the Amazon CLI with Global datastores </a>.</para>
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
        public System.String GlobalReplicationGroupIdSuffix { get; set; }
        #endregion
        
        #region Parameter PrimaryReplicationGroupId
        /// <summary>
        /// <para>
        /// <para>The name of the primary cluster that accepts writes and will replicate updates to
        /// the secondary cluster.</para>
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
        public System.String PrimaryReplicationGroupId { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'GlobalReplicationGroup'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.ElastiCache.Model.CreateGlobalReplicationGroupResponse).
        /// Specifying the name of a property of type Amazon.ElastiCache.Model.CreateGlobalReplicationGroupResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "GlobalReplicationGroup";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the PrimaryReplicationGroupId parameter.
        /// The -PassThru parameter is deprecated, use -Select '^PrimaryReplicationGroupId' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^PrimaryReplicationGroupId' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.PrimaryReplicationGroupId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-ECGlobalReplicationGroup (CreateGlobalReplicationGroup)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.ElastiCache.Model.CreateGlobalReplicationGroupResponse, NewECGlobalReplicationGroupCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.PrimaryReplicationGroupId;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.GlobalReplicationGroupDescription = this.GlobalReplicationGroupDescription;
            context.GlobalReplicationGroupIdSuffix = this.GlobalReplicationGroupIdSuffix;
            #if MODULAR
            if (this.GlobalReplicationGroupIdSuffix == null && ParameterWasBound(nameof(this.GlobalReplicationGroupIdSuffix)))
            {
                WriteWarning("You are passing $null as a value for parameter GlobalReplicationGroupIdSuffix which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.PrimaryReplicationGroupId = this.PrimaryReplicationGroupId;
            #if MODULAR
            if (this.PrimaryReplicationGroupId == null && ParameterWasBound(nameof(this.PrimaryReplicationGroupId)))
            {
                WriteWarning("You are passing $null as a value for parameter PrimaryReplicationGroupId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.ElastiCache.Model.CreateGlobalReplicationGroupRequest();
            
            if (cmdletContext.GlobalReplicationGroupDescription != null)
            {
                request.GlobalReplicationGroupDescription = cmdletContext.GlobalReplicationGroupDescription;
            }
            if (cmdletContext.GlobalReplicationGroupIdSuffix != null)
            {
                request.GlobalReplicationGroupIdSuffix = cmdletContext.GlobalReplicationGroupIdSuffix;
            }
            if (cmdletContext.PrimaryReplicationGroupId != null)
            {
                request.PrimaryReplicationGroupId = cmdletContext.PrimaryReplicationGroupId;
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
        
        private Amazon.ElastiCache.Model.CreateGlobalReplicationGroupResponse CallAWSServiceOperation(IAmazonElastiCache client, Amazon.ElastiCache.Model.CreateGlobalReplicationGroupRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon ElastiCache", "CreateGlobalReplicationGroup");
            try
            {
                #if DESKTOP
                return client.CreateGlobalReplicationGroup(request);
                #elif CORECLR
                return client.CreateGlobalReplicationGroupAsync(request).GetAwaiter().GetResult();
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
            public System.String GlobalReplicationGroupDescription { get; set; }
            public System.String GlobalReplicationGroupIdSuffix { get; set; }
            public System.String PrimaryReplicationGroupId { get; set; }
            public System.Func<Amazon.ElastiCache.Model.CreateGlobalReplicationGroupResponse, NewECGlobalReplicationGroupCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.GlobalReplicationGroup;
        }
        
    }
}
