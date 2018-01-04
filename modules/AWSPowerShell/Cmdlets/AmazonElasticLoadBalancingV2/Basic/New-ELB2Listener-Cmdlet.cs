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
using Amazon.ElasticLoadBalancingV2;
using Amazon.ElasticLoadBalancingV2.Model;

namespace Amazon.PowerShell.Cmdlets.ELB2
{
    /// <summary>
    /// Creates a listener for the specified Application Load Balancer or Network Load Balancer.
    /// 
    ///  
    /// <para>
    /// To update a listener, use <a>ModifyListener</a>. When you are finished with a listener,
    /// you can delete it using <a>DeleteListener</a>. If you are finished with both the listener
    /// and the load balancer, you can delete them both using <a>DeleteLoadBalancer</a>.
    /// </para><para>
    /// This operation is idempotent, which means that it completes at most one time. If you
    /// attempt to create multiple listeners with the same settings, each call succeeds.
    /// </para><para>
    /// For more information, see <a href="http://docs.aws.amazon.com/elasticloadbalancing/latest/application/load-balancer-listeners.html">Listeners
    /// for Your Application Load Balancers</a> in the <i>Application Load Balancers Guide</i>
    /// and <a href="http://docs.aws.amazon.com/elasticloadbalancing/latest/network/load-balancer-listeners.html">Listeners
    /// for Your Network Load Balancers</a> in the <i>Network Load Balancers Guide</i>.
    /// </para>
    /// </summary>
    [Cmdlet("New", "ELB2Listener", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.ElasticLoadBalancingV2.Model.Listener")]
    [AWSCmdlet("Calls the Elastic Load Balancing V2 CreateListener API operation.", Operation = new[] {"CreateListener"})]
    [AWSCmdletOutput("Amazon.ElasticLoadBalancingV2.Model.Listener",
        "This cmdlet returns a collection of Listener objects.",
        "The service call response (type Amazon.ElasticLoadBalancingV2.Model.CreateListenerResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class NewELB2ListenerCmdlet : AmazonElasticLoadBalancingV2ClientCmdlet, IExecutor
    {
        
        #region Parameter Certificate
        /// <summary>
        /// <para>
        /// <para>[HTTPS listeners] The SSL server certificate. You must provide exactly one certificate.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("Certificates")]
        public Amazon.ElasticLoadBalancingV2.Model.Certificate[] Certificate { get; set; }
        #endregion
        
        #region Parameter DefaultAction
        /// <summary>
        /// <para>
        /// <para>The default action for the listener. For Application Load Balancers, the protocol
        /// of the specified target group must be HTTP or HTTPS. For Network Load Balancers, the
        /// protocol of the specified target group must be TCP.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("DefaultActions")]
        public Amazon.ElasticLoadBalancingV2.Model.Action[] DefaultAction { get; set; }
        #endregion
        
        #region Parameter LoadBalancerArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the load balancer.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public System.String LoadBalancerArn { get; set; }
        #endregion
        
        #region Parameter Port
        /// <summary>
        /// <para>
        /// <para>The port on which the load balancer is listening.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.Int32 Port { get; set; }
        #endregion
        
        #region Parameter Protocol
        /// <summary>
        /// <para>
        /// <para>The protocol for connections from clients to the load balancer. For Application Load
        /// Balancers, the supported protocols are HTTP and HTTPS. For Network Load Balancers,
        /// the supported protocol is TCP.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [AWSConstantClassSource("Amazon.ElasticLoadBalancingV2.ProtocolEnum")]
        public Amazon.ElasticLoadBalancingV2.ProtocolEnum Protocol { get; set; }
        #endregion
        
        #region Parameter SslPolicy
        /// <summary>
        /// <para>
        /// <para>[HTTPS listeners] The security policy that defines which ciphers and protocols are
        /// supported. The default is the current predefined security policy.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String SslPolicy { get; set; }
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg("LoadBalancerArn", MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-ELB2Listener (CreateListener)"))
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
            
            if (this.Certificate != null)
            {
                context.Certificates = new List<Amazon.ElasticLoadBalancingV2.Model.Certificate>(this.Certificate);
            }
            if (this.DefaultAction != null)
            {
                context.DefaultActions = new List<Amazon.ElasticLoadBalancingV2.Model.Action>(this.DefaultAction);
            }
            context.LoadBalancerArn = this.LoadBalancerArn;
            if (ParameterWasBound("Port"))
                context.Port = this.Port;
            context.Protocol = this.Protocol;
            context.SslPolicy = this.SslPolicy;
            
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
            var request = new Amazon.ElasticLoadBalancingV2.Model.CreateListenerRequest();
            
            if (cmdletContext.Certificates != null)
            {
                request.Certificates = cmdletContext.Certificates;
            }
            if (cmdletContext.DefaultActions != null)
            {
                request.DefaultActions = cmdletContext.DefaultActions;
            }
            if (cmdletContext.LoadBalancerArn != null)
            {
                request.LoadBalancerArn = cmdletContext.LoadBalancerArn;
            }
            if (cmdletContext.Port != null)
            {
                request.Port = cmdletContext.Port.Value;
            }
            if (cmdletContext.Protocol != null)
            {
                request.Protocol = cmdletContext.Protocol;
            }
            if (cmdletContext.SslPolicy != null)
            {
                request.SslPolicy = cmdletContext.SslPolicy;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = CallAWSServiceOperation(client, request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = response.Listeners;
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
        
        private Amazon.ElasticLoadBalancingV2.Model.CreateListenerResponse CallAWSServiceOperation(IAmazonElasticLoadBalancingV2 client, Amazon.ElasticLoadBalancingV2.Model.CreateListenerRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Elastic Load Balancing V2", "CreateListener");
            try
            {
                #if DESKTOP
                return client.CreateListener(request);
                #elif CORECLR
                // todo: handle AggregateException and extract true service exception for rethrow
                var task = client.CreateListenerAsync(request);
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
            public List<Amazon.ElasticLoadBalancingV2.Model.Certificate> Certificates { get; set; }
            public List<Amazon.ElasticLoadBalancingV2.Model.Action> DefaultActions { get; set; }
            public System.String LoadBalancerArn { get; set; }
            public System.Int32? Port { get; set; }
            public Amazon.ElasticLoadBalancingV2.ProtocolEnum Protocol { get; set; }
            public System.String SslPolicy { get; set; }
        }
        
    }
}
