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
using Amazon.SimpleEmailV2;
using Amazon.SimpleEmailV2.Model;

namespace Amazon.PowerShell.Cmdlets.SES2
{
    /// <summary>
    /// Create a new pool of dedicated IP addresses. A pool can include one or more dedicated
    /// IP addresses that are associated with your Amazon Web Services account. You can associate
    /// a pool with a configuration set. When you send an email that uses that configuration
    /// set, the message is sent from one of the addresses in the associated pool.
    /// </summary>
    [Cmdlet("New", "SES2DedicatedIpPool", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("None")]
    [AWSCmdlet("Calls the Amazon Simple Email Service V2 (SES V2) CreateDedicatedIpPool API operation.", Operation = new[] {"CreateDedicatedIpPool"}, SelectReturnType = typeof(Amazon.SimpleEmailV2.Model.CreateDedicatedIpPoolResponse))]
    [AWSCmdletOutput("None or Amazon.SimpleEmailV2.Model.CreateDedicatedIpPoolResponse",
        "This cmdlet does not generate any output." +
        "The service response (type Amazon.SimpleEmailV2.Model.CreateDedicatedIpPoolResponse) be returned by specifying '-Select *'."
    )]
    public partial class NewSES2DedicatedIpPoolCmdlet : AmazonSimpleEmailServiceV2ClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter PoolName
        /// <summary>
        /// <para>
        /// <para>The name of the dedicated IP pool.</para>
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
        public System.String PoolName { get; set; }
        #endregion
        
        #region Parameter ScalingMode
        /// <summary>
        /// <para>
        /// <para>The type of scaling mode.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.SimpleEmailV2.ScalingMode")]
        public Amazon.SimpleEmailV2.ScalingMode ScalingMode { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>An object that defines the tags (keys and values) that you want to associate with
        /// the pool.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public Amazon.SimpleEmailV2.Model.Tag[] Tag { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The cmdlet doesn't have a return value by default.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.SimpleEmailV2.Model.CreateDedicatedIpPoolResponse).
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
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
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.PoolName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-SES2DedicatedIpPool (CreateDedicatedIpPool)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.SimpleEmailV2.Model.CreateDedicatedIpPoolResponse, NewSES2DedicatedIpPoolCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.PoolName = this.PoolName;
            #if MODULAR
            if (this.PoolName == null && ParameterWasBound(nameof(this.PoolName)))
            {
                WriteWarning("You are passing $null as a value for parameter PoolName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ScalingMode = this.ScalingMode;
            if (this.Tag != null)
            {
                context.Tag = new List<Amazon.SimpleEmailV2.Model.Tag>(this.Tag);
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
            var request = new Amazon.SimpleEmailV2.Model.CreateDedicatedIpPoolRequest();
            
            if (cmdletContext.PoolName != null)
            {
                request.PoolName = cmdletContext.PoolName;
            }
            if (cmdletContext.ScalingMode != null)
            {
                request.ScalingMode = cmdletContext.ScalingMode;
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
        
        private Amazon.SimpleEmailV2.Model.CreateDedicatedIpPoolResponse CallAWSServiceOperation(IAmazonSimpleEmailServiceV2 client, Amazon.SimpleEmailV2.Model.CreateDedicatedIpPoolRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Simple Email Service V2 (SES V2)", "CreateDedicatedIpPool");
            try
            {
                return client.CreateDedicatedIpPoolAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String PoolName { get; set; }
            public Amazon.SimpleEmailV2.ScalingMode ScalingMode { get; set; }
            public List<Amazon.SimpleEmailV2.Model.Tag> Tag { get; set; }
            public System.Func<Amazon.SimpleEmailV2.Model.CreateDedicatedIpPoolResponse, NewSES2DedicatedIpPoolCmdlet, object> Select { get; set; } =
                (response, cmdlet) => null;
        }
        
    }
}
