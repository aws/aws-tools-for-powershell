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
    /// Gets information about the traffic policy instances that you created in a specified
    /// hosted zone.
    /// 
    ///  <note><para>
    /// After you submit an <code>UpdateTrafficPolicyInstance</code> request, there's a brief
    /// delay while Amazon Route 53 creates the resource record sets that are specified in
    /// the traffic policy definition. For more information, see the <code>State</code> response
    /// element.
    /// </para></note><para>
    /// Send a <code>GET</code> request to the <code>/<i>Amazon Route 53 API version</i>/trafficpolicyinstance</code>
    /// resource and include the ID of the hosted zone.
    /// </para><para>
    /// Amazon Route 53 returns a maximum of 100 items in each response. If you have a lot
    /// of traffic policy instances, you can use the <code>MaxItems</code> parameter to list
    /// them in groups of up to 100.
    /// </para><para>
    /// The response includes four values that help you navigate from one group of <code>MaxItems</code>
    /// traffic policy instances to the next:
    /// </para><ul><li><para><b>IsTruncated</b></para><para>
    /// If the value of <code />IsTruncated in the response is <code>true</code>, there are
    /// more traffic policy instances associated with the current AWS account.
    /// </para><para>
    /// If <code>IsTruncated</code> is <code>false</code>, this response includes the last
    /// traffic policy instance that is associated with the current account.
    /// </para></li><li><para><b>MaxItems</b></para><para>
    /// The value that you specified for the <code>MaxItems</code> parameter in the request
    /// that produced the current response.
    /// </para></li><li><para><b>TrafficPolicyInstanceNameMarker</b> and <b>TrafficPolicyInstanceTypeMarker</b></para><para>
    /// If <code>IsTruncated</code> is <code>true</code>, these two values in the response
    /// represent the first traffic policy instance in the next group of <code>MaxItems</code>
    /// traffic policy instances. To list more traffic policy instances, make another call
    /// to <code>ListTrafficPolicyInstancesByHostedZone</code>, and specify these values in
    /// the corresponding request parameters.
    /// </para><para>
    /// If <code>IsTruncated</code> is <code>false</code>, all three elements are omitted
    /// from the response.
    /// </para></li></ul>
    /// </summary>
    [Cmdlet("Get", "R53TrafficPolicyInstancesByHostedZone")]
    [OutputType("Amazon.Route53.Model.ListTrafficPolicyInstancesByHostedZoneResponse")]
    [AWSCmdlet("Invokes the ListTrafficPolicyInstancesByHostedZone operation against Amazon Route 53.", Operation = new[] {"ListTrafficPolicyInstancesByHostedZone"})]
    [AWSCmdletOutput("Amazon.Route53.Model.ListTrafficPolicyInstancesByHostedZoneResponse",
        "This cmdlet returns a Amazon.Route53.Model.ListTrafficPolicyInstancesByHostedZoneResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class GetR53TrafficPolicyInstancesByHostedZoneCmdlet : AmazonRoute53ClientCmdlet, IExecutor
    {
        
        #region Parameter HostedZoneId
        /// <summary>
        /// <para>
        /// <para>The ID of the hosted zone for which you want to list traffic policy instances.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public System.String HostedZoneId { get; set; }
        #endregion
        
        #region Parameter TrafficPolicyInstanceNameMarker
        /// <summary>
        /// <para>
        /// <para>For the first request to <code>ListTrafficPolicyInstancesByHostedZone</code>, omit
        /// this value.</para><para>If the value of <code>IsTruncated</code> in the previous response was <code>true</code>,
        /// <code>TrafficPolicyInstanceNameMarker</code> is the name of the first traffic policy
        /// instance in the next group of <code>MaxItems</code> traffic policy instances.</para><para>If the value of <code>IsTruncated</code> in the previous response was <code>false</code>,
        /// there are no more traffic policy instances to get for this hosted zone.</para><para>If the value of <code>IsTruncated</code> in the previous response was <code>false</code>,
        /// omit this value.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String TrafficPolicyInstanceNameMarker { get; set; }
        #endregion
        
        #region Parameter TrafficPolicyInstanceTypeMarker
        /// <summary>
        /// <para>
        /// <para>For the first request to <code>ListTrafficPolicyInstancesByHostedZone</code>, omit
        /// this value.</para><para>If the value of <code>IsTruncated</code> in the previous response was <code>true</code>,
        /// <code>TrafficPolicyInstanceTypeMarker</code> is the DNS type of the first traffic
        /// policy instance in the next group of <code>MaxItems</code> traffic policy instances.</para><para>If the value of <code>IsTruncated</code> in the previous response was <code>false</code>,
        /// there are no more traffic policy instances to get for this hosted zone.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [AWSConstantClassSource("Amazon.Route53.RRType")]
        public Amazon.Route53.RRType TrafficPolicyInstanceTypeMarker { get; set; }
        #endregion
        
        #region Parameter MaxItem
        /// <summary>
        /// <para>
        /// <para>The maximum number of traffic policy instances to be included in the response body
        /// for this request. If you have more than <code>MaxItems</code> traffic policy instances,
        /// the value of the <code>IsTruncated</code> element in the response is <code>true</code>,
        /// and the values of <code>HostedZoneIdMarker</code>, <code>TrafficPolicyInstanceNameMarker</code>,
        /// and <code>TrafficPolicyInstanceTypeMarker</code> represent the first traffic policy
        /// instance in the next group of <code>MaxItems</code> traffic policy instances.</para>
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
            
            context.HostedZoneId = this.HostedZoneId;
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
            var request = new Amazon.Route53.Model.ListTrafficPolicyInstancesByHostedZoneRequest();
            
            if (cmdletContext.HostedZoneId != null)
            {
                request.HostedZoneId = cmdletContext.HostedZoneId;
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
        
        private static Amazon.Route53.Model.ListTrafficPolicyInstancesByHostedZoneResponse CallAWSServiceOperation(IAmazonRoute53 client, Amazon.Route53.Model.ListTrafficPolicyInstancesByHostedZoneRequest request)
        {
            #if DESKTOP
            return client.ListTrafficPolicyInstancesByHostedZone(request);
            #elif CORECLR
            // todo: handle AggregateException and extract true service exception for rethrow
            var task = client.ListTrafficPolicyInstancesByHostedZoneAsync(request);
            return task.Result;
            #else
                    #error "Unknown build edition"
            #endif
        }
        
        #endregion
        
        internal class CmdletContext : ExecutorContext
        {
            public System.String HostedZoneId { get; set; }
            public System.String TrafficPolicyInstanceNameMarker { get; set; }
            public Amazon.Route53.RRType TrafficPolicyInstanceTypeMarker { get; set; }
            public System.String MaxItems { get; set; }
        }
        
    }
}
