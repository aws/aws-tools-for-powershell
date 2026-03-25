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
using Amazon.Uxc;
using Amazon.Uxc.Model;

namespace Amazon.PowerShell.Cmdlets.UXC
{
    /// <summary>
    /// Returns the current account customization settings, including account color, visible
    /// services, and visible Regions. Settings that you have not configured return their
    /// default values: visible Regions and visible services return `null`, and account color
    /// returns `none`.
    /// 
    ///  <note><para>
    /// The <c>visibleServices</c> and <c>visibleRegions</c> settings control only the appearance
    /// of services and Regions in the Amazon Web Services Management Console. They do not
    /// restrict access through the CLI, SDKs, or other APIs.
    /// </para></note>
    /// </summary>
    [Cmdlet("Get", "UXCAccountCustomization")]
    [OutputType("Amazon.Uxc.Model.GetAccountCustomizationsResponse")]
    [AWSCmdlet("Calls the AWSAccountUXSetting GetAccountCustomizations API operation.", Operation = new[] {"GetAccountCustomizations"}, SelectReturnType = typeof(Amazon.Uxc.Model.GetAccountCustomizationsResponse))]
    [AWSCmdletOutput("Amazon.Uxc.Model.GetAccountCustomizationsResponse",
        "This cmdlet returns an Amazon.Uxc.Model.GetAccountCustomizationsResponse object containing multiple properties."
    )]
    public partial class GetUXCAccountCustomizationCmdlet : AmazonUxcClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Uxc.Model.GetAccountCustomizationsResponse).
        /// Specifying the name of a property of type Amazon.Uxc.Model.GetAccountCustomizationsResponse will result in that property being returned.
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
                context.Select = CreateSelectDelegate<Amazon.Uxc.Model.GetAccountCustomizationsResponse, GetUXCAccountCustomizationCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
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
            var request = new Amazon.Uxc.Model.GetAccountCustomizationsRequest();
            
            
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
        
        private Amazon.Uxc.Model.GetAccountCustomizationsResponse CallAWSServiceOperation(IAmazonUxc client, Amazon.Uxc.Model.GetAccountCustomizationsRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWSAccountUXSetting", "GetAccountCustomizations");
            try
            {
                #if DESKTOP
                return client.GetAccountCustomizations(request);
                #elif CORECLR
                return client.GetAccountCustomizationsAsync(request).GetAwaiter().GetResult();
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
            public System.Func<Amazon.Uxc.Model.GetAccountCustomizationsResponse, GetUXCAccountCustomizationCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
