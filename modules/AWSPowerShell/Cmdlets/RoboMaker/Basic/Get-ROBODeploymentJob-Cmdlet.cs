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
using Amazon.RoboMaker;
using Amazon.RoboMaker.Model;

namespace Amazon.PowerShell.Cmdlets.ROBO
{
    /// <summary>
    /// <important><para>
    /// End of support notice: On September 10, 2025, Amazon Web Services will discontinue
    /// support for Amazon Web Services RoboMaker. After September 10, 2025, you will no longer
    /// be able to access the Amazon Web Services RoboMaker console or Amazon Web Services
    /// RoboMaker resources. For more information on transitioning to Batch to help run containerized
    /// simulations, visit <a href="https://aws.amazon.com/blogs/hpc/run-simulations-using-multiple-containers-in-a-single-aws-batch-job/">https://aws.amazon.com/blogs/hpc/run-simulations-using-multiple-containers-in-a-single-aws-batch-job/</a>.
    /// 
    /// </para></important><important><para>
    /// This API is no longer supported. For more information, see the May 2, 2022 update
    /// in the <a href="https://docs.aws.amazon.com/robomaker/latest/dg/chapter-support-policy.html#software-support-policy-may2022">Support
    /// policy</a> page.
    /// </para></important><para>
    /// Describes a deployment job.
    /// </para><br/><br/>This operation is deprecated.
    /// </summary>
    [Cmdlet("Get", "ROBODeploymentJob")]
    [OutputType("Amazon.RoboMaker.Model.DescribeDeploymentJobResponse")]
    [AWSCmdlet("Calls the AWS RoboMaker DescribeDeploymentJob API operation.", Operation = new[] {"DescribeDeploymentJob"}, SelectReturnType = typeof(Amazon.RoboMaker.Model.DescribeDeploymentJobResponse))]
    [AWSCmdletOutput("Amazon.RoboMaker.Model.DescribeDeploymentJobResponse",
        "This cmdlet returns an Amazon.RoboMaker.Model.DescribeDeploymentJobResponse object containing multiple properties."
    )]
    [System.ObsoleteAttribute("Support for the AWS RoboMaker application deployment feature has ended. For additional information, see https://docs.aws.amazon.com/robomaker/latest/dg/fleets.html.")]
    public partial class GetROBODeploymentJobCmdlet : AmazonRoboMakerClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter Job
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the deployment job.</para>
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
        public System.String Job { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.RoboMaker.Model.DescribeDeploymentJobResponse).
        /// Specifying the name of a property of type Amazon.RoboMaker.Model.DescribeDeploymentJobResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the Job parameter.
        /// The -PassThru parameter is deprecated, use -Select '^Job' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^Job' instead. This parameter will be removed in a future version.")]
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public SwitchParameter PassThru { get; set; }
        #endregion
        
        protected override void ProcessRecord()
        {
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.RoboMaker.Model.DescribeDeploymentJobResponse, GetROBODeploymentJobCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.Job;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.Job = this.Job;
            #if MODULAR
            if (this.Job == null && ParameterWasBound(nameof(this.Job)))
            {
                WriteWarning("You are passing $null as a value for parameter Job which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.RoboMaker.Model.DescribeDeploymentJobRequest();
            
            if (cmdletContext.Job != null)
            {
                request.Job = cmdletContext.Job;
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
        
        private Amazon.RoboMaker.Model.DescribeDeploymentJobResponse CallAWSServiceOperation(IAmazonRoboMaker client, Amazon.RoboMaker.Model.DescribeDeploymentJobRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS RoboMaker", "DescribeDeploymentJob");
            try
            {
                #if DESKTOP
                return client.DescribeDeploymentJob(request);
                #elif CORECLR
                return client.DescribeDeploymentJobAsync(request).GetAwaiter().GetResult();
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
            public System.String Job { get; set; }
            public System.Func<Amazon.RoboMaker.Model.DescribeDeploymentJobResponse, GetROBODeploymentJobCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
