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
using Amazon.DirectConnect;
using Amazon.DirectConnect.Model;

namespace Amazon.PowerShell.Cmdlets.DC
{
    /// <summary>
    /// Starts the virtual interface failover test that verifies your configuration meets
    /// your resiliency requirements by placing the BGP peering session in the DOWN state.
    /// You can then send traffic to verify that there are no outages.
    /// 
    ///  
    /// <para>
    /// You can run the test on public, private, transit, and hosted virtual interfaces.
    /// </para><para>
    /// You can use <a href="https://docs.aws.amazon.com/directconnect/latest/APIReference/API_ListVirtualInterfaceTestHistory.html">ListVirtualInterfaceTestHistory</a>
    /// to view the virtual interface test history.
    /// </para><para>
    /// If you need to stop the test before the test interval completes, use <a href="https://docs.aws.amazon.com/directconnect/latest/APIReference/API_StopBgpFailoverTest.html">StopBgpFailoverTest</a>.
    /// </para>
    /// </summary>
    [Cmdlet("Start", "DCBgpFailoverTest", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.DirectConnect.Model.VirtualInterfaceTestHistory")]
    [AWSCmdlet("Calls the AWS Direct Connect StartBgpFailoverTest API operation.", Operation = new[] {"StartBgpFailoverTest"}, SelectReturnType = typeof(Amazon.DirectConnect.Model.StartBgpFailoverTestResponse))]
    [AWSCmdletOutput("Amazon.DirectConnect.Model.VirtualInterfaceTestHistory or Amazon.DirectConnect.Model.StartBgpFailoverTestResponse",
        "This cmdlet returns an Amazon.DirectConnect.Model.VirtualInterfaceTestHistory object.",
        "The service call response (type Amazon.DirectConnect.Model.StartBgpFailoverTestResponse) can be returned by specifying '-Select *'."
    )]
    public partial class StartDCBgpFailoverTestCmdlet : AmazonDirectConnectClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter BgpPeer
        /// <summary>
        /// <para>
        /// <para>The BGP peers to place in the DOWN state.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("BgpPeers")]
        public System.String[] BgpPeer { get; set; }
        #endregion
        
        #region Parameter TestDurationInMinute
        /// <summary>
        /// <para>
        /// <para>The time in minutes that the virtual interface failover test will last.</para><para>Maximum value: 4,320 minutes (72 hours).</para><para>Default: 180 minutes (3 hours).</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("TestDurationInMinutes")]
        public System.Int32? TestDurationInMinute { get; set; }
        #endregion
        
        #region Parameter VirtualInterfaceId
        /// <summary>
        /// <para>
        /// <para>The ID of the virtual interface you want to test.</para>
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
        public System.String VirtualInterfaceId { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'VirtualInterfaceTest'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.DirectConnect.Model.StartBgpFailoverTestResponse).
        /// Specifying the name of a property of type Amazon.DirectConnect.Model.StartBgpFailoverTestResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "VirtualInterfaceTest";
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
        
        protected override void ProcessRecord()
        {
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.VirtualInterfaceId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Start-DCBgpFailoverTest (StartBgpFailoverTest)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.DirectConnect.Model.StartBgpFailoverTestResponse, StartDCBgpFailoverTestCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            if (this.BgpPeer != null)
            {
                context.BgpPeer = new List<System.String>(this.BgpPeer);
            }
            context.TestDurationInMinute = this.TestDurationInMinute;
            context.VirtualInterfaceId = this.VirtualInterfaceId;
            #if MODULAR
            if (this.VirtualInterfaceId == null && ParameterWasBound(nameof(this.VirtualInterfaceId)))
            {
                WriteWarning("You are passing $null as a value for parameter VirtualInterfaceId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.DirectConnect.Model.StartBgpFailoverTestRequest();
            
            if (cmdletContext.BgpPeer != null)
            {
                request.BgpPeers = cmdletContext.BgpPeer;
            }
            if (cmdletContext.TestDurationInMinute != null)
            {
                request.TestDurationInMinutes = cmdletContext.TestDurationInMinute.Value;
            }
            if (cmdletContext.VirtualInterfaceId != null)
            {
                request.VirtualInterfaceId = cmdletContext.VirtualInterfaceId;
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
        
        private Amazon.DirectConnect.Model.StartBgpFailoverTestResponse CallAWSServiceOperation(IAmazonDirectConnect client, Amazon.DirectConnect.Model.StartBgpFailoverTestRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Direct Connect", "StartBgpFailoverTest");
            try
            {
                #if DESKTOP
                return client.StartBgpFailoverTest(request);
                #elif CORECLR
                return client.StartBgpFailoverTestAsync(request).GetAwaiter().GetResult();
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
            public List<System.String> BgpPeer { get; set; }
            public System.Int32? TestDurationInMinute { get; set; }
            public System.String VirtualInterfaceId { get; set; }
            public System.Func<Amazon.DirectConnect.Model.StartBgpFailoverTestResponse, StartDCBgpFailoverTestCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.VirtualInterfaceTest;
        }
        
    }
}
