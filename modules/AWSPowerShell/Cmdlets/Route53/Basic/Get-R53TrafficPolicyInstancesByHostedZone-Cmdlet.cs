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
using Amazon.Route53;
using Amazon.Route53.Model;

namespace Amazon.PowerShell.Cmdlets.R53
{
    /// <summary>
    /// Gets information about the traffic policy instances that you created in a specified
    /// hosted zone.
    /// 
    ///  <note><para>
    /// After you submit a <c>CreateTrafficPolicyInstance</c> or an <c>UpdateTrafficPolicyInstance</c>
    /// request, there's a brief delay while Amazon Route 53 creates the resource record sets
    /// that are specified in the traffic policy definition. For more information, see the
    /// <c>State</c> response element.
    /// </para></note><para>
    /// Route 53 returns a maximum of 100 items in each response. If you have a lot of traffic
    /// policy instances, you can use the <c>MaxItems</c> parameter to list them in groups
    /// of up to 100.
    /// </para>
    /// </summary>
    [Cmdlet("Get", "R53TrafficPolicyInstancesByHostedZone")]
    [OutputType("Amazon.Route53.Model.ListTrafficPolicyInstancesByHostedZoneResponse")]
    [AWSCmdlet("Calls the Amazon Route 53 ListTrafficPolicyInstancesByHostedZone API operation.", Operation = new[] {"ListTrafficPolicyInstancesByHostedZone"}, SelectReturnType = typeof(Amazon.Route53.Model.ListTrafficPolicyInstancesByHostedZoneResponse))]
    [AWSCmdletOutput("Amazon.Route53.Model.ListTrafficPolicyInstancesByHostedZoneResponse",
        "This cmdlet returns an Amazon.Route53.Model.ListTrafficPolicyInstancesByHostedZoneResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class GetR53TrafficPolicyInstancesByHostedZoneCmdlet : AmazonRoute53ClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter HostedZoneId
        /// <summary>
        /// <para>
        /// <para>The ID of the hosted zone that you want to list traffic policy instances for.</para>
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
        [Alias("Id")]
        public System.String HostedZoneId { get; set; }
        #endregion
        
        #region Parameter TrafficPolicyInstanceNameMarker
        /// <summary>
        /// <para>
        /// <para>If the value of <c>IsTruncated</c> in the previous response is true, you have more
        /// traffic policy instances. To get more traffic policy instances, submit another <c>ListTrafficPolicyInstances</c>
        /// request. For the value of <c>trafficpolicyinstancename</c>, specify the value of <c>TrafficPolicyInstanceNameMarker</c>
        /// from the previous response, which is the name of the first traffic policy instance
        /// in the next group of traffic policy instances.</para><para>If the value of <c>IsTruncated</c> in the previous response was <c>false</c>, there
        /// are no more traffic policy instances to get.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String TrafficPolicyInstanceNameMarker { get; set; }
        #endregion
        
        #region Parameter TrafficPolicyInstanceTypeMarker
        /// <summary>
        /// <para>
        /// <para>If the value of <c>IsTruncated</c> in the previous response is true, you have more
        /// traffic policy instances. To get more traffic policy instances, submit another <c>ListTrafficPolicyInstances</c>
        /// request. For the value of <c>trafficpolicyinstancetype</c>, specify the value of <c>TrafficPolicyInstanceTypeMarker</c>
        /// from the previous response, which is the type of the first traffic policy instance
        /// in the next group of traffic policy instances.</para><para>If the value of <c>IsTruncated</c> in the previous response was <c>false</c>, there
        /// are no more traffic policy instances to get.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.Route53.RRType")]
        public Amazon.Route53.RRType TrafficPolicyInstanceTypeMarker { get; set; }
        #endregion
        
        #region Parameter MaxItem
        /// <summary>
        /// <para>
        /// <para>The maximum number of traffic policy instances to be included in the response body
        /// for this request. If you have more than <c>MaxItems</c> traffic policy instances,
        /// the value of the <c>IsTruncated</c> element in the response is <c>true</c>, and the
        /// values of <c>HostedZoneIdMarker</c>, <c>TrafficPolicyInstanceNameMarker</c>, and <c>TrafficPolicyInstanceTypeMarker</c>
        /// represent the first traffic policy instance that Amazon Route 53 will return if you
        /// submit another request.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MaxItems")]
        public System.String MaxItem { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Route53.Model.ListTrafficPolicyInstancesByHostedZoneResponse).
        /// Specifying the name of a property of type Amazon.Route53.Model.ListTrafficPolicyInstancesByHostedZoneResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        protected override void ProcessRecord()
        {
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Route53.Model.ListTrafficPolicyInstancesByHostedZoneResponse, GetR53TrafficPolicyInstancesByHostedZoneCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.HostedZoneId = this.HostedZoneId;
            #if MODULAR
            if (this.HostedZoneId == null && ParameterWasBound(nameof(this.HostedZoneId)))
            {
                WriteWarning("You are passing $null as a value for parameter HostedZoneId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.TrafficPolicyInstanceNameMarker = this.TrafficPolicyInstanceNameMarker;
            context.TrafficPolicyInstanceTypeMarker = this.TrafficPolicyInstanceTypeMarker;
            context.MaxItem = this.MaxItem;
            
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
            if (cmdletContext.MaxItem != null)
            {
                request.MaxItems = cmdletContext.MaxItem;
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
        
        private Amazon.Route53.Model.ListTrafficPolicyInstancesByHostedZoneResponse CallAWSServiceOperation(IAmazonRoute53 client, Amazon.Route53.Model.ListTrafficPolicyInstancesByHostedZoneRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Route 53", "ListTrafficPolicyInstancesByHostedZone");
            try
            {
                #if DESKTOP
                return client.ListTrafficPolicyInstancesByHostedZone(request);
                #elif CORECLR
                return client.ListTrafficPolicyInstancesByHostedZoneAsync(request).GetAwaiter().GetResult();
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
            public System.String HostedZoneId { get; set; }
            public System.String TrafficPolicyInstanceNameMarker { get; set; }
            public Amazon.Route53.RRType TrafficPolicyInstanceTypeMarker { get; set; }
            public System.String MaxItem { get; set; }
            public System.Func<Amazon.Route53.Model.ListTrafficPolicyInstancesByHostedZoneResponse, GetR53TrafficPolicyInstancesByHostedZoneCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
