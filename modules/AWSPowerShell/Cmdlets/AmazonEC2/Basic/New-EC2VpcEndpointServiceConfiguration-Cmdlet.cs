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
using Amazon.EC2;
using Amazon.EC2.Model;

namespace Amazon.PowerShell.Cmdlets.EC2
{
    /// <summary>
    /// Creates a VPC endpoint service configuration to which service consumers (AWS accounts,
    /// IAM users, and IAM roles) can connect. Service consumers can create an interface VPC
    /// endpoint to connect to your service.
    /// 
    ///  
    /// <para>
    /// To create an endpoint service configuration, you must first create a Network Load
    /// Balancer for your service. For more information, see <a href="http://docs.aws.amazon.com/AmazonVPC/latest/UserGuide/endpoint-service.html">VPC
    /// Endpoint Services</a> in the <i>Amazon Virtual Private Cloud User Guide</i>. 
    /// </para>
    /// </summary>
    [Cmdlet("New", "EC2VpcEndpointServiceConfiguration", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.EC2.Model.CreateVpcEndpointServiceConfigurationResponse")]
    [AWSCmdlet("Calls the Amazon Elastic Compute Cloud CreateVpcEndpointServiceConfiguration API operation.", Operation = new[] {"CreateVpcEndpointServiceConfiguration"})]
    [AWSCmdletOutput("Amazon.EC2.Model.CreateVpcEndpointServiceConfigurationResponse",
        "This cmdlet returns a Amazon.EC2.Model.CreateVpcEndpointServiceConfigurationResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class NewEC2VpcEndpointServiceConfigurationCmdlet : AmazonEC2ClientCmdlet, IExecutor
    {
        
        #region Parameter AcceptanceRequired
        /// <summary>
        /// <para>
        /// <para>Indicate whether requests from service consumers to create an endpoint to your service
        /// must be accepted. To accept a request, use <a>AcceptVpcEndpointConnections</a>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.Boolean AcceptanceRequired { get; set; }
        #endregion
        
        #region Parameter ClientToken
        /// <summary>
        /// <para>
        /// <para>Unique, case-sensitive identifier you provide to ensure the idempotency of the request.
        /// For more information, see <a href="http://docs.aws.amazon.com/AWSEC2/latest/UserGuide/Run_Instance_Idempotency.html">How
        /// to Ensure Idempotency</a>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String ClientToken { get; set; }
        #endregion
        
        #region Parameter NetworkLoadBalancerArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Names (ARNs) of one or more Network Load Balancers for your service.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipeline = true)]
        [Alias("NetworkLoadBalancerArns")]
        public System.String[] NetworkLoadBalancerArn { get; set; }
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg("NetworkLoadBalancerArn", MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-EC2VpcEndpointServiceConfiguration (CreateVpcEndpointServiceConfiguration)"))
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
            
            if (ParameterWasBound("AcceptanceRequired"))
                context.AcceptanceRequired = this.AcceptanceRequired;
            context.ClientToken = this.ClientToken;
            if (this.NetworkLoadBalancerArn != null)
            {
                context.NetworkLoadBalancerArns = new List<System.String>(this.NetworkLoadBalancerArn);
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
            var request = new Amazon.EC2.Model.CreateVpcEndpointServiceConfigurationRequest();
            
            if (cmdletContext.AcceptanceRequired != null)
            {
                request.AcceptanceRequired = cmdletContext.AcceptanceRequired.Value;
            }
            if (cmdletContext.ClientToken != null)
            {
                request.ClientToken = cmdletContext.ClientToken;
            }
            if (cmdletContext.NetworkLoadBalancerArns != null)
            {
                request.NetworkLoadBalancerArns = cmdletContext.NetworkLoadBalancerArns;
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
        
        private Amazon.EC2.Model.CreateVpcEndpointServiceConfigurationResponse CallAWSServiceOperation(IAmazonEC2 client, Amazon.EC2.Model.CreateVpcEndpointServiceConfigurationRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Elastic Compute Cloud", "CreateVpcEndpointServiceConfiguration");
            try
            {
                #if DESKTOP
                return client.CreateVpcEndpointServiceConfiguration(request);
                #elif CORECLR
                // todo: handle AggregateException and extract true service exception for rethrow
                var task = client.CreateVpcEndpointServiceConfigurationAsync(request);
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
            public System.Boolean? AcceptanceRequired { get; set; }
            public System.String ClientToken { get; set; }
            public List<System.String> NetworkLoadBalancerArns { get; set; }
        }
        
    }
}
