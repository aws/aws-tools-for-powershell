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
using Amazon.WorkMail;
using Amazon.WorkMail.Model;

namespace Amazon.PowerShell.Cmdlets.WM
{
    /// <summary>
    /// Simulates the effect of the mobile device access rules for the given attributes of
    /// a sample access event. Use this method to test the effects of the current set of mobile
    /// device access rules for the WorkMail organization for a particular user's attributes.
    /// </summary>
    [Cmdlet("Get", "WMMobileDeviceAccessEffect")]
    [OutputType("Amazon.WorkMail.Model.GetMobileDeviceAccessEffectResponse")]
    [AWSCmdlet("Calls the Amazon WorkMail GetMobileDeviceAccessEffect API operation.", Operation = new[] {"GetMobileDeviceAccessEffect"}, SelectReturnType = typeof(Amazon.WorkMail.Model.GetMobileDeviceAccessEffectResponse))]
    [AWSCmdletOutput("Amazon.WorkMail.Model.GetMobileDeviceAccessEffectResponse",
        "This cmdlet returns an Amazon.WorkMail.Model.GetMobileDeviceAccessEffectResponse object containing multiple properties."
    )]
    public partial class GetWMMobileDeviceAccessEffectCmdlet : AmazonWorkMailClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter DeviceModel
        /// <summary>
        /// <para>
        /// <para>Device model the simulated user will report.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String DeviceModel { get; set; }
        #endregion
        
        #region Parameter DeviceOperatingSystem
        /// <summary>
        /// <para>
        /// <para>Device operating system the simulated user will report.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String DeviceOperatingSystem { get; set; }
        #endregion
        
        #region Parameter DeviceType
        /// <summary>
        /// <para>
        /// <para>Device type the simulated user will report.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String DeviceType { get; set; }
        #endregion
        
        #region Parameter DeviceUserAgent
        /// <summary>
        /// <para>
        /// <para>Device user agent the simulated user will report.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String DeviceUserAgent { get; set; }
        #endregion
        
        #region Parameter OrganizationId
        /// <summary>
        /// <para>
        /// <para>The WorkMail organization to simulate the access effect for.</para>
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
        public System.String OrganizationId { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.WorkMail.Model.GetMobileDeviceAccessEffectResponse).
        /// Specifying the name of a property of type Amazon.WorkMail.Model.GetMobileDeviceAccessEffectResponse will result in that property being returned.
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
                context.Select = CreateSelectDelegate<Amazon.WorkMail.Model.GetMobileDeviceAccessEffectResponse, GetWMMobileDeviceAccessEffectCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.DeviceModel = this.DeviceModel;
            context.DeviceOperatingSystem = this.DeviceOperatingSystem;
            context.DeviceType = this.DeviceType;
            context.DeviceUserAgent = this.DeviceUserAgent;
            context.OrganizationId = this.OrganizationId;
            #if MODULAR
            if (this.OrganizationId == null && ParameterWasBound(nameof(this.OrganizationId)))
            {
                WriteWarning("You are passing $null as a value for parameter OrganizationId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.WorkMail.Model.GetMobileDeviceAccessEffectRequest();
            
            if (cmdletContext.DeviceModel != null)
            {
                request.DeviceModel = cmdletContext.DeviceModel;
            }
            if (cmdletContext.DeviceOperatingSystem != null)
            {
                request.DeviceOperatingSystem = cmdletContext.DeviceOperatingSystem;
            }
            if (cmdletContext.DeviceType != null)
            {
                request.DeviceType = cmdletContext.DeviceType;
            }
            if (cmdletContext.DeviceUserAgent != null)
            {
                request.DeviceUserAgent = cmdletContext.DeviceUserAgent;
            }
            if (cmdletContext.OrganizationId != null)
            {
                request.OrganizationId = cmdletContext.OrganizationId;
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
        
        private Amazon.WorkMail.Model.GetMobileDeviceAccessEffectResponse CallAWSServiceOperation(IAmazonWorkMail client, Amazon.WorkMail.Model.GetMobileDeviceAccessEffectRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon WorkMail", "GetMobileDeviceAccessEffect");
            try
            {
                #if DESKTOP
                return client.GetMobileDeviceAccessEffect(request);
                #elif CORECLR
                return client.GetMobileDeviceAccessEffectAsync(request).GetAwaiter().GetResult();
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
            public System.String DeviceModel { get; set; }
            public System.String DeviceOperatingSystem { get; set; }
            public System.String DeviceType { get; set; }
            public System.String DeviceUserAgent { get; set; }
            public System.String OrganizationId { get; set; }
            public System.Func<Amazon.WorkMail.Model.GetMobileDeviceAccessEffectResponse, GetWMMobileDeviceAccessEffectCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
