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
using Amazon.ElasticBeanstalk;
using Amazon.ElasticBeanstalk.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.EB
{
    /// <summary>
    /// Swaps the CNAMEs of two environments.
    /// </summary>
    [Cmdlet("Set", "EBEnvironmentCNAME", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("None")]
    [AWSCmdlet("Calls the AWS Elastic Beanstalk SwapEnvironmentCNAMEs API operation.", Operation = new[] {"SwapEnvironmentCNAMEs"}, SelectReturnType = typeof(Amazon.ElasticBeanstalk.Model.SwapEnvironmentCNAMEsResponse), LegacyAlias="Set-EBEnvironmentCNAMEs")]
    [AWSCmdletOutput("None or Amazon.ElasticBeanstalk.Model.SwapEnvironmentCNAMEsResponse",
        "This cmdlet does not generate any output." +
        "The service response (type Amazon.ElasticBeanstalk.Model.SwapEnvironmentCNAMEsResponse) be returned by specifying '-Select *'."
    )]
    public partial class SetEBEnvironmentCNAMECmdlet : AmazonElasticBeanstalkClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter DestinationEnvironmentId
        /// <summary>
        /// <para>
        /// <para>The ID of the destination environment.</para><para> Condition: You must specify at least the <c>DestinationEnvironmentID</c> or the <c>DestinationEnvironmentName</c>.
        /// You may also specify both. You must specify the <c>SourceEnvironmentId</c> with the
        /// <c>DestinationEnvironmentId</c>. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 2, ValueFromPipelineByPropertyName = true)]
        public System.String DestinationEnvironmentId { get; set; }
        #endregion
        
        #region Parameter DestinationEnvironmentName
        /// <summary>
        /// <para>
        /// <para>The name of the destination environment.</para><para> Condition: You must specify at least the <c>DestinationEnvironmentID</c> or the <c>DestinationEnvironmentName</c>.
        /// You may also specify both. You must specify the <c>SourceEnvironmentName</c> with
        /// the <c>DestinationEnvironmentName</c>. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 3, ValueFromPipelineByPropertyName = true)]
        public System.String DestinationEnvironmentName { get; set; }
        #endregion
        
        #region Parameter SourceEnvironmentId
        /// <summary>
        /// <para>
        /// <para>The ID of the source environment.</para><para> Condition: You must specify at least the <c>SourceEnvironmentID</c> or the <c>SourceEnvironmentName</c>.
        /// You may also specify both. If you specify the <c>SourceEnvironmentId</c>, you must
        /// specify the <c>DestinationEnvironmentId</c>. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public System.String SourceEnvironmentId { get; set; }
        #endregion
        
        #region Parameter SourceEnvironmentName
        /// <summary>
        /// <para>
        /// <para>The name of the source environment.</para><para> Condition: You must specify at least the <c>SourceEnvironmentID</c> or the <c>SourceEnvironmentName</c>.
        /// You may also specify both. If you specify the <c>SourceEnvironmentName</c>, you must
        /// specify the <c>DestinationEnvironmentName</c>. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 1, ValueFromPipelineByPropertyName = true)]
        public System.String SourceEnvironmentName { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The cmdlet doesn't have a return value by default.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.ElasticBeanstalk.Model.SwapEnvironmentCNAMEsResponse).
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
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.SourceEnvironmentId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Set-EBEnvironmentCNAME (SwapEnvironmentCNAMEs)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.ElasticBeanstalk.Model.SwapEnvironmentCNAMEsResponse, SetEBEnvironmentCNAMECmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.DestinationEnvironmentId = this.DestinationEnvironmentId;
            context.DestinationEnvironmentName = this.DestinationEnvironmentName;
            context.SourceEnvironmentId = this.SourceEnvironmentId;
            context.SourceEnvironmentName = this.SourceEnvironmentName;
            
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
            var request = new Amazon.ElasticBeanstalk.Model.SwapEnvironmentCNAMEsRequest();
            
            if (cmdletContext.DestinationEnvironmentId != null)
            {
                request.DestinationEnvironmentId = cmdletContext.DestinationEnvironmentId;
            }
            if (cmdletContext.DestinationEnvironmentName != null)
            {
                request.DestinationEnvironmentName = cmdletContext.DestinationEnvironmentName;
            }
            if (cmdletContext.SourceEnvironmentId != null)
            {
                request.SourceEnvironmentId = cmdletContext.SourceEnvironmentId;
            }
            if (cmdletContext.SourceEnvironmentName != null)
            {
                request.SourceEnvironmentName = cmdletContext.SourceEnvironmentName;
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
        
        private Amazon.ElasticBeanstalk.Model.SwapEnvironmentCNAMEsResponse CallAWSServiceOperation(IAmazonElasticBeanstalk client, Amazon.ElasticBeanstalk.Model.SwapEnvironmentCNAMEsRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Elastic Beanstalk", "SwapEnvironmentCNAMEs");
            try
            {
                return client.SwapEnvironmentCNAMEsAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String DestinationEnvironmentId { get; set; }
            public System.String DestinationEnvironmentName { get; set; }
            public System.String SourceEnvironmentId { get; set; }
            public System.String SourceEnvironmentName { get; set; }
            public System.Func<Amazon.ElasticBeanstalk.Model.SwapEnvironmentCNAMEsResponse, SetEBEnvironmentCNAMECmdlet, object> Select { get; set; } =
                (response, cmdlet) => null;
        }
        
    }
}
