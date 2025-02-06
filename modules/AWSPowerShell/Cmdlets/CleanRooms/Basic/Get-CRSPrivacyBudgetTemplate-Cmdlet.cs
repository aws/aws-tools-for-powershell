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
using Amazon.CleanRooms;
using Amazon.CleanRooms.Model;

namespace Amazon.PowerShell.Cmdlets.CRS
{
    /// <summary>
    /// Returns details for a specified privacy budget template.
    /// </summary>
    [Cmdlet("Get", "CRSPrivacyBudgetTemplate")]
    [OutputType("Amazon.CleanRooms.Model.PrivacyBudgetTemplate")]
    [AWSCmdlet("Calls the AWS Clean Rooms Service GetPrivacyBudgetTemplate API operation.", Operation = new[] {"GetPrivacyBudgetTemplate"}, SelectReturnType = typeof(Amazon.CleanRooms.Model.GetPrivacyBudgetTemplateResponse))]
    [AWSCmdletOutput("Amazon.CleanRooms.Model.PrivacyBudgetTemplate or Amazon.CleanRooms.Model.GetPrivacyBudgetTemplateResponse",
        "This cmdlet returns an Amazon.CleanRooms.Model.PrivacyBudgetTemplate object.",
        "The service call response (type Amazon.CleanRooms.Model.GetPrivacyBudgetTemplateResponse) can be returned by specifying '-Select *'."
    )]
    public partial class GetCRSPrivacyBudgetTemplateCmdlet : AmazonCleanRoomsClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter MembershipIdentifier
        /// <summary>
        /// <para>
        /// <para>A unique identifier for one of your memberships for a collaboration. The privacy budget
        /// template is retrieved from the collaboration that this membership belongs to. Accepts
        /// a membership ID.</para>
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
        public System.String MembershipIdentifier { get; set; }
        #endregion
        
        #region Parameter PrivacyBudgetTemplateIdentifier
        /// <summary>
        /// <para>
        /// <para>A unique identifier for your privacy budget template.</para>
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
        public System.String PrivacyBudgetTemplateIdentifier { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'PrivacyBudgetTemplate'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.CleanRooms.Model.GetPrivacyBudgetTemplateResponse).
        /// Specifying the name of a property of type Amazon.CleanRooms.Model.GetPrivacyBudgetTemplateResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "PrivacyBudgetTemplate";
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
                context.Select = CreateSelectDelegate<Amazon.CleanRooms.Model.GetPrivacyBudgetTemplateResponse, GetCRSPrivacyBudgetTemplateCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.MembershipIdentifier = this.MembershipIdentifier;
            #if MODULAR
            if (this.MembershipIdentifier == null && ParameterWasBound(nameof(this.MembershipIdentifier)))
            {
                WriteWarning("You are passing $null as a value for parameter MembershipIdentifier which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.PrivacyBudgetTemplateIdentifier = this.PrivacyBudgetTemplateIdentifier;
            #if MODULAR
            if (this.PrivacyBudgetTemplateIdentifier == null && ParameterWasBound(nameof(this.PrivacyBudgetTemplateIdentifier)))
            {
                WriteWarning("You are passing $null as a value for parameter PrivacyBudgetTemplateIdentifier which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.CleanRooms.Model.GetPrivacyBudgetTemplateRequest();
            
            if (cmdletContext.MembershipIdentifier != null)
            {
                request.MembershipIdentifier = cmdletContext.MembershipIdentifier;
            }
            if (cmdletContext.PrivacyBudgetTemplateIdentifier != null)
            {
                request.PrivacyBudgetTemplateIdentifier = cmdletContext.PrivacyBudgetTemplateIdentifier;
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
        
        private Amazon.CleanRooms.Model.GetPrivacyBudgetTemplateResponse CallAWSServiceOperation(IAmazonCleanRooms client, Amazon.CleanRooms.Model.GetPrivacyBudgetTemplateRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Clean Rooms Service", "GetPrivacyBudgetTemplate");
            try
            {
                #if DESKTOP
                return client.GetPrivacyBudgetTemplate(request);
                #elif CORECLR
                return client.GetPrivacyBudgetTemplateAsync(request).GetAwaiter().GetResult();
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
            public System.String MembershipIdentifier { get; set; }
            public System.String PrivacyBudgetTemplateIdentifier { get; set; }
            public System.Func<Amazon.CleanRooms.Model.GetPrivacyBudgetTemplateResponse, GetCRSPrivacyBudgetTemplateCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.PrivacyBudgetTemplate;
        }
        
    }
}
