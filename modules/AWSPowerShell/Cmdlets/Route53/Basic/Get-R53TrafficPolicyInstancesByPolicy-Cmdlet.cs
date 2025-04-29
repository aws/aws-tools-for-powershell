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
using Amazon.Route53;
using Amazon.Route53.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.R53
{
    /// <summary>
    /// Gets information about the traffic policy instances that you created by using a specify
    /// traffic policy version.
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
    [Cmdlet("Get", "R53TrafficPolicyInstancesByPolicy")]
    [OutputType("Amazon.Route53.Model.ListTrafficPolicyInstancesByPolicyResponse")]
    [AWSCmdlet("Calls the Amazon Route 53 ListTrafficPolicyInstancesByPolicy API operation.", Operation = new[] {"ListTrafficPolicyInstancesByPolicy"}, SelectReturnType = typeof(Amazon.Route53.Model.ListTrafficPolicyInstancesByPolicyResponse))]
    [AWSCmdletOutput("Amazon.Route53.Model.ListTrafficPolicyInstancesByPolicyResponse",
        "This cmdlet returns an Amazon.Route53.Model.ListTrafficPolicyInstancesByPolicyResponse object containing multiple properties."
    )]
    public partial class GetR53TrafficPolicyInstancesByPolicyCmdlet : AmazonRoute53ClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter HostedZoneIdMarker
        /// <summary>
        /// <para>
        /// <para>If the value of <c>IsTruncated</c> in the previous response was <c>true</c>, you have
        /// more traffic policy instances. To get more traffic policy instances, submit another
        /// <c>ListTrafficPolicyInstancesByPolicy</c> request. </para><para>For the value of <c>hostedzoneid</c>, specify the value of <c>HostedZoneIdMarker</c>
        /// from the previous response, which is the hosted zone ID of the first traffic policy
        /// instance that Amazon Route 53 will return if you submit another request.</para><para>If the value of <c>IsTruncated</c> in the previous response was <c>false</c>, there
        /// are no more traffic policy instances to get.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String HostedZoneIdMarker { get; set; }
        #endregion
        
        #region Parameter TrafficPolicyId
        /// <summary>
        /// <para>
        /// <para>The ID of the traffic policy for which you want to list traffic policy instances.</para>
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
        public System.String TrafficPolicyId { get; set; }
        #endregion
        
        #region Parameter TrafficPolicyInstanceNameMarker
        /// <summary>
        /// <para>
        /// <para>If the value of <c>IsTruncated</c> in the previous response was <c>true</c>, you have
        /// more traffic policy instances. To get more traffic policy instances, submit another
        /// <c>ListTrafficPolicyInstancesByPolicy</c> request.</para><para>For the value of <c>trafficpolicyinstancename</c>, specify the value of <c>TrafficPolicyInstanceNameMarker</c>
        /// from the previous response, which is the name of the first traffic policy instance
        /// that Amazon Route 53 will return if you submit another request.</para><para>If the value of <c>IsTruncated</c> in the previous response was <c>false</c>, there
        /// are no more traffic policy instances to get.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String TrafficPolicyInstanceNameMarker { get; set; }
        #endregion
        
        #region Parameter TrafficPolicyInstanceTypeMarker
        /// <summary>
        /// <para>
        /// <para>If the value of <c>IsTruncated</c> in the previous response was <c>true</c>, you have
        /// more traffic policy instances. To get more traffic policy instances, submit another
        /// <c>ListTrafficPolicyInstancesByPolicy</c> request.</para><para>For the value of <c>trafficpolicyinstancetype</c>, specify the value of <c>TrafficPolicyInstanceTypeMarker</c>
        /// from the previous response, which is the name of the first traffic policy instance
        /// that Amazon Route 53 will return if you submit another request.</para><para>If the value of <c>IsTruncated</c> in the previous response was <c>false</c>, there
        /// are no more traffic policy instances to get.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.Route53.RRType")]
        public Amazon.Route53.RRType TrafficPolicyInstanceTypeMarker { get; set; }
        #endregion
        
        #region Parameter TrafficPolicyVersion
        /// <summary>
        /// <para>
        /// <para>The version of the traffic policy for which you want to list traffic policy instances.
        /// The version must be associated with the traffic policy that is specified by <c>TrafficPolicyId</c>.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.Int32? TrafficPolicyVersion { get; set; }
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
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Route53.Model.ListTrafficPolicyInstancesByPolicyResponse).
        /// Specifying the name of a property of type Amazon.Route53.Model.ListTrafficPolicyInstancesByPolicyResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        protected override void StopProcessing()
        {
            base.StopProcessing();
            _cancellationTokenSource.Cancel();
        }
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Route53.Model.ListTrafficPolicyInstancesByPolicyResponse, GetR53TrafficPolicyInstancesByPolicyCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.TrafficPolicyId = this.TrafficPolicyId;
            #if MODULAR
            if (this.TrafficPolicyId == null && ParameterWasBound(nameof(this.TrafficPolicyId)))
            {
                WriteWarning("You are passing $null as a value for parameter TrafficPolicyId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.TrafficPolicyVersion = this.TrafficPolicyVersion;
            #if MODULAR
            if (this.TrafficPolicyVersion == null && ParameterWasBound(nameof(this.TrafficPolicyVersion)))
            {
                WriteWarning("You are passing $null as a value for parameter TrafficPolicyVersion which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.HostedZoneIdMarker = this.HostedZoneIdMarker;
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
        
        private Amazon.Route53.Model.ListTrafficPolicyInstancesByPolicyResponse CallAWSServiceOperation(IAmazonRoute53 client, Amazon.Route53.Model.ListTrafficPolicyInstancesByPolicyRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Route 53", "ListTrafficPolicyInstancesByPolicy");
            try
            {
                return client.ListTrafficPolicyInstancesByPolicyAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String MaxItem { get; set; }
            public System.Func<Amazon.Route53.Model.ListTrafficPolicyInstancesByPolicyResponse, GetR53TrafficPolicyInstancesByPolicyCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
