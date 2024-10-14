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
using Amazon.WellArchitected;
using Amazon.WellArchitected.Model;

namespace Amazon.PowerShell.Cmdlets.WAT
{
    /// <summary>
    /// Delete an existing lens.
    /// 
    ///  
    /// <para>
    /// Only the owner of a lens can delete it. After the lens is deleted, Amazon Web Services
    /// accounts and users that you shared the lens with can continue to use it, but they
    /// will no longer be able to apply it to new workloads. 
    /// </para><note><para><b>Disclaimer</b></para><para>
    /// By sharing your custom lenses with other Amazon Web Services accounts, you acknowledge
    /// that Amazon Web Services will make your custom lenses available to those other accounts.
    /// Those other accounts may continue to access and use your shared custom lenses even
    /// if you delete the custom lenses from your own Amazon Web Services account or terminate
    /// your Amazon Web Services account.
    /// </para></note>
    /// </summary>
    [Cmdlet("Remove", "WATLens", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.High)]
    [OutputType("None")]
    [AWSCmdlet("Calls the AWS Well-Architected Tool DeleteLens API operation.", Operation = new[] {"DeleteLens"}, SelectReturnType = typeof(Amazon.WellArchitected.Model.DeleteLensResponse))]
    [AWSCmdletOutput("None or Amazon.WellArchitected.Model.DeleteLensResponse",
        "This cmdlet does not generate any output." +
        "The service response (type Amazon.WellArchitected.Model.DeleteLensResponse) be returned by specifying '-Select *'."
    )]
    public partial class RemoveWATLensCmdlet : AmazonWellArchitectedClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter ClientRequestToken
        /// <summary>
        /// <para>
        /// The service has not provided documentation for this parameter; please refer to the service's API reference documentation for the latest available information.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ClientRequestToken { get; set; }
        #endregion
        
        #region Parameter LensAlias
        /// <summary>
        /// <para>
        /// The service has not provided documentation for this parameter; please refer to the service's API reference documentation for the latest available information.
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyString]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.String LensAlias { get; set; }
        #endregion
        
        #region Parameter LensStatus
        /// <summary>
        /// <para>
        /// <para>The status of the lens to be deleted.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.WellArchitected.LensStatusType")]
        public Amazon.WellArchitected.LensStatusType LensStatus { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The cmdlet doesn't have a return value by default.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.WellArchitected.Model.DeleteLensResponse).
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
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
            
            var resourceIdentifiersText = string.Empty;
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Remove-WATLens (DeleteLens)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.WellArchitected.Model.DeleteLensResponse, RemoveWATLensCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.ClientRequestToken = this.ClientRequestToken;
            context.LensAlias = this.LensAlias;
            #if MODULAR
            if (this.LensAlias == null && ParameterWasBound(nameof(this.LensAlias)))
            {
                WriteWarning("You are passing $null as a value for parameter LensAlias which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.LensStatus = this.LensStatus;
            #if MODULAR
            if (this.LensStatus == null && ParameterWasBound(nameof(this.LensStatus)))
            {
                WriteWarning("You are passing $null as a value for parameter LensStatus which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.WellArchitected.Model.DeleteLensRequest();
            
            if (cmdletContext.ClientRequestToken != null)
            {
                request.ClientRequestToken = cmdletContext.ClientRequestToken;
            }
            if (cmdletContext.LensAlias != null)
            {
                request.LensAlias = cmdletContext.LensAlias;
            }
            if (cmdletContext.LensStatus != null)
            {
                request.LensStatus = cmdletContext.LensStatus;
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
        
        private Amazon.WellArchitected.Model.DeleteLensResponse CallAWSServiceOperation(IAmazonWellArchitected client, Amazon.WellArchitected.Model.DeleteLensRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Well-Architected Tool", "DeleteLens");
            try
            {
                #if DESKTOP
                return client.DeleteLens(request);
                #elif CORECLR
                return client.DeleteLensAsync(request).GetAwaiter().GetResult();
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
            public System.String ClientRequestToken { get; set; }
            public System.String LensAlias { get; set; }
            public Amazon.WellArchitected.LensStatusType LensStatus { get; set; }
            public System.Func<Amazon.WellArchitected.Model.DeleteLensResponse, RemoveWATLensCmdlet, object> Select { get; set; } =
                (response, cmdlet) => null;
        }
        
    }
}
