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
using Amazon.ControlCatalog;
using Amazon.ControlCatalog.Model;

namespace Amazon.PowerShell.Cmdlets.CLCAT
{
    /// <summary>
    /// Returns details about a specific control, most notably a list of Amazon Web Services
    /// Regions where this control is supported. Input a value for the <i>ControlArn</i> parameter,
    /// in ARN form. <c>GetControl</c> accepts <i>controltower</i> or <i>controlcatalog</i>
    /// control ARNs as input. Returns a <i>controlcatalog</i> ARN format.
    /// 
    ///  
    /// <para>
    /// In the API response, controls that have the value <c>GLOBAL</c> in the <c>Scope</c>
    /// field do not show the <c>DeployableRegions</c> field, because it does not apply. Controls
    /// that have the value <c>REGIONAL</c> in the <c>Scope</c> field return a value for the
    /// <c>DeployableRegions</c> field, as shown in the example.
    /// </para>
    /// </summary>
    [Cmdlet("Get", "CLCATControl")]
    [OutputType("Amazon.ControlCatalog.Model.GetControlResponse")]
    [AWSCmdlet("Calls the AWS Control Catalog GetControl API operation.", Operation = new[] {"GetControl"}, SelectReturnType = typeof(Amazon.ControlCatalog.Model.GetControlResponse))]
    [AWSCmdletOutput("Amazon.ControlCatalog.Model.GetControlResponse",
        "This cmdlet returns an Amazon.ControlCatalog.Model.GetControlResponse object containing multiple properties."
    )]
    public partial class GetCLCATControlCmdlet : AmazonControlCatalogClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter ControlArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the control. It has one of the following formats:</para><para><i>Global format</i></para><para><c>arn:{PARTITION}:controlcatalog:::control/{CONTROL_CATALOG_OPAQUE_ID}</c></para><para><i>Or Regional format</i></para><para><c>arn:{PARTITION}:controltower:{REGION}::control/{CONTROL_TOWER_OPAQUE_ID}</c></para><para>Here is a more general pattern that covers Amazon Web Services Control Tower and Control
        /// Catalog ARNs:</para><para><c>^arn:(aws(?:[-a-z]*)?):(controlcatalog|controltower):[a-zA-Z0-9-]*::control/[0-9a-zA-Z_\\-]+$</c></para>
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
        public System.String ControlArn { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.ControlCatalog.Model.GetControlResponse).
        /// Specifying the name of a property of type Amazon.ControlCatalog.Model.GetControlResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the ControlArn parameter.
        /// The -PassThru parameter is deprecated, use -Select '^ControlArn' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^ControlArn' instead. This parameter will be removed in a future version.")]
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public SwitchParameter PassThru { get; set; }
        #endregion
        
        protected override void ProcessRecord()
        {
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.ControlCatalog.Model.GetControlResponse, GetCLCATControlCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.ControlArn;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.ControlArn = this.ControlArn;
            #if MODULAR
            if (this.ControlArn == null && ParameterWasBound(nameof(this.ControlArn)))
            {
                WriteWarning("You are passing $null as a value for parameter ControlArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.ControlCatalog.Model.GetControlRequest();
            
            if (cmdletContext.ControlArn != null)
            {
                request.ControlArn = cmdletContext.ControlArn;
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
        
        private Amazon.ControlCatalog.Model.GetControlResponse CallAWSServiceOperation(IAmazonControlCatalog client, Amazon.ControlCatalog.Model.GetControlRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Control Catalog", "GetControl");
            try
            {
                #if DESKTOP
                return client.GetControl(request);
                #elif CORECLR
                return client.GetControlAsync(request).GetAwaiter().GetResult();
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
            public System.String ControlArn { get; set; }
            public System.Func<Amazon.ControlCatalog.Model.GetControlResponse, GetCLCATControlCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
