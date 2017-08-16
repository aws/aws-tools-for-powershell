/*******************************************************************************
 *  Copyright 2012-2015 Amazon.com, Inc. or its affiliates. All Rights Reserved.
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
using Amazon.ElasticBeanstalk;
using Amazon.ElasticBeanstalk.Model;

namespace Amazon.PowerShell.Cmdlets.EB
{
    /// <summary>
    /// Terminates the specified environment.
    /// </summary>
    [Cmdlet("Stop", "EBEnvironment", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.ElasticBeanstalk.Model.TerminateEnvironmentResponse")]
    [AWSCmdlet("Invokes the TerminateEnvironment operation against AWS Elastic Beanstalk.", Operation = new[] {"TerminateEnvironment"})]
    [AWSCmdletOutput("Amazon.ElasticBeanstalk.Model.TerminateEnvironmentResponse",
        "This cmdlet returns a Amazon.ElasticBeanstalk.Model.TerminateEnvironmentResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class StopEBEnvironmentCmdlet : AmazonElasticBeanstalkClientCmdlet, IExecutor
    {
        
        #region Parameter EnvironmentId
        /// <summary>
        /// <para>
        /// <para>The ID of the environment to terminate.</para><para> Condition: You must specify either this or an EnvironmentName, or both. If you do
        /// not specify either, AWS Elastic Beanstalk returns <code>MissingRequiredParameter</code>
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
        /// specify either, AWS Elastic Beanstalk returns <code>MissingRequiredParameter</code>
        /// error. </para>
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
        [System.Management.Automation.Parameter]
        public System.Boolean ForceTerminate { get; set; }
        #endregion
        
        #region Parameter TerminateResource
        /// <summary>
        /// <para>
        /// <para>Indicates whether the associated AWS resources should shut down when the environment
        /// is terminated:</para><ul><li><para><code>true</code>: The specified environment as well as the associated AWS resources,
        /// such as Auto Scaling group and LoadBalancer, are terminated.</para></li><li><para><code>false</code>: AWS Elastic Beanstalk resource management is removed from the
        /// environment, but the AWS resources continue to operate.</para></li></ul><para> For more information, see the <a href="http://docs.aws.amazon.com/elasticbeanstalk/latest/ug/">
        /// AWS Elastic Beanstalk User Guide. </a></para><para> Default: <code>true</code></para><para> Valid Values: <code>true</code> | <code>false</code></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 2)]
        [Alias("TerminateResources")]
        public System.Boolean TerminateResource { get; set; }
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg("EnvironmentId", MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Stop-EBEnvironment (TerminateEnvironment)"))
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
            
            context.EnvironmentId = this.EnvironmentId;
            context.EnvironmentName = this.EnvironmentName;
            if (ParameterWasBound("ForceTerminate"))
                context.ForceTerminate = this.ForceTerminate;
            if (ParameterWasBound("TerminateResource"))
                context.TerminateResources = this.TerminateResource;
            
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
            if (cmdletContext.TerminateResources != null)
            {
                request.TerminateResources = cmdletContext.TerminateResources.Value;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = CallAWSServiceOperation(client, request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = response;
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
        
        private Amazon.ElasticBeanstalk.Model.TerminateEnvironmentResponse CallAWSServiceOperation(IAmazonElasticBeanstalk client, Amazon.ElasticBeanstalk.Model.TerminateEnvironmentRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Elastic Beanstalk", "TerminateEnvironment");
            try
            {
                #if DESKTOP
                return client.TerminateEnvironment(request);
                #elif CORECLR
                // todo: handle AggregateException and extract true service exception for rethrow
                var task = client.TerminateEnvironmentAsync(request);
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
            public System.String EnvironmentId { get; set; }
            public System.String EnvironmentName { get; set; }
            public System.Boolean? ForceTerminate { get; set; }
            public System.Boolean? TerminateResources { get; set; }
        }
        
    }
}
