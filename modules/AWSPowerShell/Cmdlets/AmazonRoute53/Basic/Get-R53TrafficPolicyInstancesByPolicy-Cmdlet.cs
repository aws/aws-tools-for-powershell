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
using Amazon.Route53;
using Amazon.Route53.Model;

namespace Amazon.PowerShell.Cmdlets.R53
{
    /// <summary>
    /// Gets information about the traffic policy instances that you created by using a specify
    /// traffic policy version.
    /// 
    ///  <note><para>
    /// After you submit a <code>CreateTrafficPolicyInstance</code> or an <code>UpdateTrafficPolicyInstance</code>
    /// request, there's a brief delay while Amazon Route 53 creates the resource record sets
    /// that are specified in the traffic policy definition. For more information, see the
    /// <code>State</code> response element.
    /// </para></note><para>
    /// Amazon Route 53 returns a maximum of 100 items in each response. If you have a lot
    /// of traffic policy instances, you can use the <code>MaxItems</code> parameter to list
    /// them in groups of up to 100.
    /// </para>
    /// </summary>
    [Cmdlet("Get", "R53TrafficPolicyInstancesByPolicy")]
    [OutputType("Amazon.Route53.Model.ListTrafficPolicyInstancesByPolicyResponse")]
    [AWSCmdlet("Calls the Amazon Route 53 ListTrafficPolicyInstancesByPolicy API operation.", Operation = new[] {"ListTrafficPolicyInstancesByPolicy"})]
    [AWSCmdletOutput("Amazon.Route53.Model.ListTrafficPolicyInstancesByPolicyResponse",
        "This cmdlet returns a Amazon.Route53.Model.ListTrafficPolicyInstancesByPolicyResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class GetR53TrafficPolicyInstancesByPolicyCmdlet : AmazonRoute53ClientCmdlet, IExecutor
    {
        
        #region Parameter HostedZoneIdMarker
        /// <summary>
        /// <para>
        /// <para>If the value of <code>IsTruncated</code> in the previous response was <code>true</code>,
        /// you have more traffic policy instances. To get more traffic policy instances, submit
        /// another <code>ListTrafficPolicyInstancesByPolicy</code> request. </para><para>For the value of <code>hostedzoneid</code>, specify the value of <code>HostedZoneIdMarker</code>
        /// from the previous response, which is the hosted zone ID of the first traffic policy
        /// instance that Amazon Route 53 will return if you submit another request.</para><para>If the value of <code>IsTruncated</code> in the previous response was <code>false</code>,
        /// there are no more traffic policy instances to get.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String HostedZoneIdMarker { get; set; }
        #endregion
        
        #region Parameter TrafficPolicyId
        /// <summary>
        /// <para>
        /// <para>The ID of the traffic policy for which you want to list traffic policy instances.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipeline = true)]
        public System.String TrafficPolicyId { get; set; }
        #endregion
        
        #region Parameter TrafficPolicyInstanceNameMarker
        /// <summary>
        /// <para>
        /// <para>If the value of <code>IsTruncated</code> in the previous response was <code>true</code>,
        /// you have more traffic policy instances. To get more traffic policy instances, submit
        /// another <code>ListTrafficPolicyInstancesByPolicy</code> request.</para><para>For the value of <code>trafficpolicyinstancename</code>, specify the value of <code>TrafficPolicyInstanceNameMarker</code>
        /// from the previous response, which is the name of the first traffic policy instance
        /// that Amazon Route 53 will return if you submit another request.</para><para>If the value of <code>IsTruncated</code> in the previous response was <code>false</code>,
        /// there are no more traffic policy instances to get.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String TrafficPolicyInstanceNameMarker { get; set; }
        #endregion
        
        #region Parameter TrafficPolicyInstanceTypeMarker
        /// <summary>
        /// <para>
        /// <para>If the value of <code>IsTruncated</code> in the previous response was <code>true</code>,
        /// you have more traffic policy instances. To get more traffic policy instances, submit
        /// another <code>ListTrafficPolicyInstancesByPolicy</code> request.</para><para>For the value of <code>trafficpolicyinstancetype</code>, specify the value of <code>TrafficPolicyInstanceTypeMarker</code>
        /// from the previous response, which is the name of the first traffic policy instance
        /// that Amazon Route 53 will return if you submit another request.</para><para>If the value of <code>IsTruncated</code> in the previous response was <code>false</code>,
        /// there are no more traffic policy instances to get.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [AWSConstantClassSource("Amazon.Route53.RRType")]
        public Amazon.Route53.RRType TrafficPolicyInstanceTypeMarker { get; set; }
        #endregion
        
        #region Parameter TrafficPolicyVersion
        /// <summary>
        /// <para>
        /// <para>The version of the traffic policy for which you want to list traffic policy instances.
        /// The version must be associated with the traffic policy that is specified by <code>TrafficPolicyId</code>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.Int32 TrafficPolicyVersion { get; set; }
        #endregion
        
        #region Parameter MaxItem
        /// <summary>
        /// <para>
        /// <para>The maximum number of traffic policy instances to be included in the response body
        /// for this request. If you have more than <code>MaxItems</code> traffic policy instances,
        /// the value of the <code>IsTruncated</code> element in the response is <code>true</code>,
        /// and the values of <code>HostedZoneIdMarker</code>, <code>TrafficPolicyInstanceNameMarker</code>,
        /// and <code>TrafficPolicyInstanceTypeMarker</code> represent the first traffic policy
        /// instance that Amazon Route 53 will return if you submit another request.</para>
        /// </para>
        /// <para>
        /// <br/><b>Note:</b> This parameter is only used if you are manually controlling output pagination of the service API call.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("MaxItems")]
        public System.String MaxItem { get; set; }
        #endregion
        
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var context = new CmdletContext
            {
                Region = this.Region,
                Credentials = this.CurrentCredentials
            };
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            context.TrafficPolicyId = this.TrafficPolicyId;
            if (ParameterWasBound("TrafficPolicyVersion"))
                context.TrafficPolicyVersion = this.TrafficPolicyVersion;
            context.HostedZoneIdMarker = this.HostedZoneIdMarker;
            context.TrafficPolicyInstanceNameMarker = this.TrafficPolicyInstanceNameMarker;
            context.TrafficPolicyInstanceTypeMarker = this.TrafficPolicyInstanceTypeMarker;
            context.MaxItems = this.MaxItem;
            
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
            var request = new Amazon.Route53.Model.ListTrafficPolicyInstancesByPolicyRequest();
            
            if (cmdletContext.TrafficPolicyId != null)
            {
                request.TrafficPolicyId = cmdletContext.TrafficPolicyId;
            }
            if (cmdletContext.TrafficPolicyVersion != null)
            {
                request.TrafficPolicyVersion = cmdletContext.TrafficPolicyVersion.Value;
            }
            if (cmdletContext.HostedZoneIdMarker != null)
            {
                request.HostedZoneIdMarker = cmdletContext.HostedZoneIdMarker;
            }
            if (cmdletContext.TrafficPolicyInstanceNameMarker != null)
            {
                request.TrafficPolicyInstanceNameMarker = cmdletContext.TrafficPolicyInstanceNameMarker;
            }
            if (cmdletContext.TrafficPolicyInstanceTypeMarker != null)
            {
                request.TrafficPolicyInstanceTypeMarker = cmdletContext.TrafficPolicyInstanceTypeMarker;
            }
            if (cmdletContext.MaxItems != null)
            {
                request.MaxItems = cmdletContext.MaxItems;
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
        
        private Amazon.Route53.Model.ListTrafficPolicyInstancesByPolicyResponse CallAWSServiceOperation(IAmazonRoute53 client, Amazon.Route53.Model.ListTrafficPolicyInstancesByPolicyRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Route 53", "ListTrafficPolicyInstancesByPolicy");
            try
            {
                #if DESKTOP
                return client.ListTrafficPolicyInstancesByPolicy(request);
                #elif CORECLR
                // todo: handle AggregateException and extract true service exception for rethrow
                var task = client.ListTrafficPolicyInstancesByPolicyAsync(request);
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
            public System.String TrafficPolicyId { get; set; }
            public System.Int32? TrafficPolicyVersion { get; set; }
            public System.String HostedZoneIdMarker { get; set; }
            public System.String TrafficPolicyInstanceNameMarker { get; set; }
            public Amazon.Route53.RRType TrafficPolicyInstanceTypeMarker { get; set; }
            public System.String MaxItems { get; set; }
        }
        
    }
}
