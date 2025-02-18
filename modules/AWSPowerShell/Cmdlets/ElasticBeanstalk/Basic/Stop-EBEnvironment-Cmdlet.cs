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

namespace Amazon.PowerShell.Cmdlets.EB
{
    /// <summary>
    /// Terminates the specified environment.
    /// </summary>
    [Cmdlet("Stop", "EBEnvironment", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.ElasticBeanstalk.Model.TerminateEnvironmentResponse")]
    [AWSCmdlet("Calls the AWS Elastic Beanstalk TerminateEnvironment API operation.", Operation = new[] {"TerminateEnvironment"}, SelectReturnType = typeof(Amazon.ElasticBeanstalk.Model.TerminateEnvironmentResponse))]
    [AWSCmdletOutput("Amazon.ElasticBeanstalk.Model.TerminateEnvironmentResponse",
        "This cmdlet returns an Amazon.ElasticBeanstalk.Model.TerminateEnvironmentResponse object containing multiple properties."
    )]
    public partial class StopEBEnvironmentCmdlet : AmazonElasticBeanstalkClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter EnvironmentId
        /// <summary>
        /// <para>
        /// <para>The ID of the environment to terminate.</para><para> Condition: You must specify either this or an EnvironmentName, or both. If you do
        /// not specify either, AWS Elastic Beanstalk returns <c>MissingRequiredParameter</c>
        /// error. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public System.String EnvironmentId { get; set; }
        #endregion
        
        #region Parameter EnvironmentName
        /// <summary>
        /// <para>
        /// <para>The name of the environment to terminate.</para><para> Condition: You must specify either this or an EnvironmentId, or both. If you do not
        /// specify either, AWS Elastic Beanstalk returns <c>MissingRequiredParameter</c> error.
        /// </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 1, ValueFromPipelineByPropertyName = true)]
        public System.String EnvironmentName { get; set; }
        #endregion
        
        #region Parameter ForceTerminate
        /// <summary>
        /// <para>
        /// <para>Terminates the target environment even if another environment in the same group is
        /// dependent on it.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? ForceTerminate { get; set; }
        #endregion
        
        #region Parameter TerminateResource
        /// <summary>
        /// <para>
        /// <para>Indicates whether the associated AWS resources should shut down when the environment
        /// is terminated:</para><ul><li><para><c>true</c>: The specified environment as well as the associated AWS resources, such
        /// as Auto Scaling group and LoadBalancer, are terminated.</para></li><li><para><c>false</c>: AWS Elastic Beanstalk resource management is removed from the environment,
        /// but the AWS resources continue to operate.</para></li></ul><para> For more information, see the <a href="https://docs.aws.amazon.com/elasticbeanstalk/latest/ug/">
        /// AWS Elastic Beanstalk User Guide. </a></para><para> Default: <c>true</c></para><para> Valid Values: <c>true</c> | <c>false</c></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 2, ValueFromPipelineByPropertyName = true)]
        [Alias("TerminateResources")]
        public System.Boolean? TerminateResource { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.ElasticBeanstalk.Model.TerminateEnvironmentResponse).
        /// Specifying the name of a property of type Amazon.ElasticBeanstalk.Model.TerminateEnvironmentResponse will result in that property being returned.
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.EnvironmentId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Stop-EBEnvironment (TerminateEnvironment)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.ElasticBeanstalk.Model.TerminateEnvironmentResponse, StopEBEnvironmentCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.EnvironmentId = this.EnvironmentId;
            context.EnvironmentName = this.EnvironmentName;
            context.ForceTerminate = this.ForceTerminate;
            context.TerminateResource = this.TerminateResource;
            
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
            var request = new Amazon.ElasticBeanstalk.Model.TerminateEnvironmentRequest();
            
            if (cmdletContext.EnvironmentId != null)
            {
                request.EnvironmentId = cmdletContext.EnvironmentId;
            }
            if (cmdletContext.EnvironmentName != null)
            {
                request.EnvironmentName = cmdletContext.EnvironmentName;
            }
            if (cmdletContext.ForceTerminate != null)
            {
                request.ForceTerminate = cmdletContext.ForceTerminate.Value;
            }
            if (cmdletContext.TerminateResource != null)
            {
                request.TerminateResources = cmdletContext.TerminateResource.Value;
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
        
        private Amazon.ElasticBeanstalk.Model.TerminateEnvironmentResponse CallAWSServiceOperation(IAmazonElasticBeanstalk client, Amazon.ElasticBeanstalk.Model.TerminateEnvironmentRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Elastic Beanstalk", "TerminateEnvironment");
            try
            {
                return client.TerminateEnvironmentAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String EnvironmentId { get; set; }
            public System.String EnvironmentName { get; set; }
            public System.Boolean? ForceTerminate { get; set; }
            public System.Boolean? TerminateResource { get; set; }
            public System.Func<Amazon.ElasticBeanstalk.Model.TerminateEnvironmentResponse, StopEBEnvironmentCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
