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
using Amazon.Organizations;
using Amazon.Organizations.Model;

namespace Amazon.PowerShell.Cmdlets.ORG
{
    /// <summary>
    /// Renames the specified organizational unit (OU). The ID and ARN don't change. The child
    /// OUs and accounts remain in place, and any attached policies of the OU remain attached.
    /// 
    /// 
    ///  
    /// <para>
    /// This operation can be called only from the organization's master account.
    /// </para>
    /// </summary>
    [Cmdlet("Update", "ORGOrganizationalUnit", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.Organizations.Model.OrganizationalUnit")]
    [AWSCmdlet("Calls the AWS Organizations UpdateOrganizationalUnit API operation.", Operation = new[] {"UpdateOrganizationalUnit"}, SelectReturnType = typeof(Amazon.Organizations.Model.UpdateOrganizationalUnitResponse))]
    [AWSCmdletOutput("Amazon.Organizations.Model.OrganizationalUnit or Amazon.Organizations.Model.UpdateOrganizationalUnitResponse",
        "This cmdlet returns an Amazon.Organizations.Model.OrganizationalUnit object.",
        "The service call response (type Amazon.Organizations.Model.UpdateOrganizationalUnitResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class UpdateORGOrganizationalUnitCmdlet : AmazonOrganizationsClientCmdlet, IExecutor
    {
        
        #region Parameter Name
        /// <summary>
        /// <para>
        /// <para>The new name that you want to assign to the OU.</para><para>The <a href="http://wikipedia.org/wiki/regex">regex pattern</a> that is used to validate
        /// this parameter is a string of any of the characters in the ASCII character range.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public System.String Name { get; set; }
        #endregion
        
        #region Parameter OrganizationalUnitId
        /// <summary>
        /// <para>
        /// <para>The unique identifier (ID) of the OU that you want to rename. You can get the ID from
        /// the <a>ListOrganizationalUnitsForParent</a> operation.</para><para>The <a href="http://wikipedia.org/wiki/regex">regex pattern</a> for an organizational
        /// unit ID string requires "ou-" followed by from 4 to 32 lowercase letters or digits
        /// (the ID of the root that contains the OU). This string is followed by a second "-"
        /// dash and from 8 to 32 additional lowercase letters or digits.</para>
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
        public System.String OrganizationalUnitId { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'OrganizationalUnit'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Organizations.Model.UpdateOrganizationalUnitResponse).
        /// Specifying the name of a property of type Amazon.Organizations.Model.UpdateOrganizationalUnitResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "OrganizationalUnit";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the Name parameter.
        /// The -PassThru parameter is deprecated, use -Select '^Name' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^Name' instead. This parameter will be removed in a future version.")]
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
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.Name), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-ORGOrganizationalUnit (UpdateOrganizationalUnit)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Organizations.Model.UpdateOrganizationalUnitResponse, UpdateORGOrganizationalUnitCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.Name;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.Name = this.Name;
            context.OrganizationalUnitId = this.OrganizationalUnitId;
            #if MODULAR
            if (this.OrganizationalUnitId == null && ParameterWasBound(nameof(this.OrganizationalUnitId)))
            {
                WriteWarning("You are passing $null as a value for parameter OrganizationalUnitId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.Organizations.Model.UpdateOrganizationalUnitRequest();
            
            if (cmdletContext.Name != null)
            {
                request.Name = cmdletContext.Name;
            }
            if (cmdletContext.OrganizationalUnitId != null)
            {
                request.OrganizationalUnitId = cmdletContext.OrganizationalUnitId;
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
        
        private Amazon.Organizations.Model.UpdateOrganizationalUnitResponse CallAWSServiceOperation(IAmazonOrganizations client, Amazon.Organizations.Model.UpdateOrganizationalUnitRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Organizations", "UpdateOrganizationalUnit");
            try
            {
                #if DESKTOP
                return client.UpdateOrganizationalUnit(request);
                #elif CORECLR
                return client.UpdateOrganizationalUnitAsync(request).GetAwaiter().GetResult();
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
            public System.String Name { get; set; }
            public System.String OrganizationalUnitId { get; set; }
            public System.Func<Amazon.Organizations.Model.UpdateOrganizationalUnitResponse, UpdateORGOrganizationalUnitCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.OrganizationalUnit;
        }
        
    }
}
