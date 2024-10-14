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
using Amazon.IAMRolesAnywhere;
using Amazon.IAMRolesAnywhere.Model;

namespace Amazon.PowerShell.Cmdlets.IAMRA
{
    /// <summary>
    /// Deletes a trust anchor.
    /// 
    ///  
    /// <para><b>Required permissions: </b><c>rolesanywhere:DeleteTrustAnchor</c>. 
    /// </para>
    /// </summary>
    [Cmdlet("Remove", "IAMRATrustAnchor", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.High)]
    [OutputType("Amazon.IAMRolesAnywhere.Model.TrustAnchorDetail")]
    [AWSCmdlet("Calls the IAM Roles Anywhere DeleteTrustAnchor API operation.", Operation = new[] {"DeleteTrustAnchor"}, SelectReturnType = typeof(Amazon.IAMRolesAnywhere.Model.DeleteTrustAnchorResponse))]
    [AWSCmdletOutput("Amazon.IAMRolesAnywhere.Model.TrustAnchorDetail or Amazon.IAMRolesAnywhere.Model.DeleteTrustAnchorResponse",
        "This cmdlet returns an Amazon.IAMRolesAnywhere.Model.TrustAnchorDetail object.",
        "The service call response (type Amazon.IAMRolesAnywhere.Model.DeleteTrustAnchorResponse) can be returned by specifying '-Select *'."
    )]
    public partial class RemoveIAMRATrustAnchorCmdlet : AmazonIAMRolesAnywhereClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter TrustAnchorId
        /// <summary>
        /// <para>
        /// <para>The unique identifier of the trust anchor.</para>
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
        public System.String TrustAnchorId { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'TrustAnchor'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.IAMRolesAnywhere.Model.DeleteTrustAnchorResponse).
        /// Specifying the name of a property of type Amazon.IAMRolesAnywhere.Model.DeleteTrustAnchorResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "TrustAnchor";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the TrustAnchorId parameter.
        /// The -PassThru parameter is deprecated, use -Select '^TrustAnchorId' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^TrustAnchorId' instead. This parameter will be removed in a future version.")]
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public SwitchParameter PassThru { get; set; }
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.TrustAnchorId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Remove-IAMRATrustAnchor (DeleteTrustAnchor)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.IAMRolesAnywhere.Model.DeleteTrustAnchorResponse, RemoveIAMRATrustAnchorCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.TrustAnchorId;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.TrustAnchorId = this.TrustAnchorId;
            #if MODULAR
            if (this.TrustAnchorId == null && ParameterWasBound(nameof(this.TrustAnchorId)))
            {
                WriteWarning("You are passing $null as a value for parameter TrustAnchorId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.IAMRolesAnywhere.Model.DeleteTrustAnchorRequest();
            
            if (cmdletContext.TrustAnchorId != null)
            {
                request.TrustAnchorId = cmdletContext.TrustAnchorId;
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
        
        private Amazon.IAMRolesAnywhere.Model.DeleteTrustAnchorResponse CallAWSServiceOperation(IAmazonIAMRolesAnywhere client, Amazon.IAMRolesAnywhere.Model.DeleteTrustAnchorRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "IAM Roles Anywhere", "DeleteTrustAnchor");
            try
            {
                #if DESKTOP
                return client.DeleteTrustAnchor(request);
                #elif CORECLR
                return client.DeleteTrustAnchorAsync(request).GetAwaiter().GetResult();
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
            public System.String TrustAnchorId { get; set; }
            public System.Func<Amazon.IAMRolesAnywhere.Model.DeleteTrustAnchorResponse, RemoveIAMRATrustAnchorCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.TrustAnchor;
        }
        
    }
}
