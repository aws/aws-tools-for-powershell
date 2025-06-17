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
using Amazon.Organizations;
using Amazon.Organizations.Model;

namespace Amazon.PowerShell.Cmdlets.ORG
{
    /// <summary>
    /// Retrieves information about an organizational unit (OU).
    /// 
    ///  
    /// <para>
    /// This operation can be called only from the organization's management account or by
    /// a member account that is a delegated administrator.
    /// </para>
    /// </summary>
    [Cmdlet("Get", "ORGOrganizationalUnit")]
    [OutputType("Amazon.Organizations.Model.OrganizationalUnit")]
    [AWSCmdlet("Calls the AWS Organizations DescribeOrganizationalUnit API operation.", Operation = new[] {"DescribeOrganizationalUnit"}, SelectReturnType = typeof(Amazon.Organizations.Model.DescribeOrganizationalUnitResponse))]
    [AWSCmdletOutput("Amazon.Organizations.Model.OrganizationalUnit or Amazon.Organizations.Model.DescribeOrganizationalUnitResponse",
        "This cmdlet returns an Amazon.Organizations.Model.OrganizationalUnit object.",
        "The service call response (type Amazon.Organizations.Model.DescribeOrganizationalUnitResponse) can be returned by specifying '-Select *'."
    )]
    public partial class GetORGOrganizationalUnitCmdlet : AmazonOrganizationsClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter OrganizationalUnitId
        /// <summary>
        /// <para>
        /// <para>The unique identifier (ID) of the organizational unit that you want details about.
        /// You can get the ID from the <a>ListOrganizationalUnitsForParent</a> operation.</para><para>The <a href="http://wikipedia.org/wiki/regex">regex pattern</a> for an organizational
        /// unit ID string requires "ou-" followed by from 4 to 32 lowercase letters or digits
        /// (the ID of the root that contains the OU). This string is followed by a second "-"
        /// dash and from 8 to 32 additional lowercase letters or digits.</para>
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
        public System.String OrganizationalUnitId { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'OrganizationalUnit'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Organizations.Model.DescribeOrganizationalUnitResponse).
        /// Specifying the name of a property of type Amazon.Organizations.Model.DescribeOrganizationalUnitResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "OrganizationalUnit";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the OrganizationalUnitId parameter.
        /// The -PassThru parameter is deprecated, use -Select '^OrganizationalUnitId' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^OrganizationalUnitId' instead. This parameter will be removed in a future version.")]
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
                context.Select = CreateSelectDelegate<Amazon.Organizations.Model.DescribeOrganizationalUnitResponse, GetORGOrganizationalUnitCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.OrganizationalUnitId;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
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
            var request = new Amazon.Organizations.Model.DescribeOrganizationalUnitRequest();
            
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
        
        private Amazon.Organizations.Model.DescribeOrganizationalUnitResponse CallAWSServiceOperation(IAmazonOrganizations client, Amazon.Organizations.Model.DescribeOrganizationalUnitRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Organizations", "DescribeOrganizationalUnit");
            try
            {
                #if DESKTOP
                return client.DescribeOrganizationalUnit(request);
                #elif CORECLR
                return client.DescribeOrganizationalUnitAsync(request).GetAwaiter().GetResult();
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
            public System.String OrganizationalUnitId { get; set; }
            public System.Func<Amazon.Organizations.Model.DescribeOrganizationalUnitResponse, GetORGOrganizationalUnitCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.OrganizationalUnit;
        }
        
    }
}
