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
using Amazon.SecurityLake;
using Amazon.SecurityLake.Model;

namespace Amazon.PowerShell.Cmdlets.SLK
{
    /// <summary>
    /// Turns off automatic enablement of Amazon Security Lake for member accounts that are
    /// added to an organization in Organizations. Only the delegated Security Lake administrator
    /// for an organization can perform this operation. If the delegated Security Lake administrator
    /// performs this operation, new member accounts won't automatically contribute data to
    /// the data lake.
    /// </summary>
    [Cmdlet("Remove", "SLKDataLakeOrganizationConfiguration", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.High)]
    [OutputType("None")]
    [AWSCmdlet("Calls the Amazon Security Lake DeleteDataLakeOrganizationConfiguration API operation.", Operation = new[] {"DeleteDataLakeOrganizationConfiguration"}, SelectReturnType = typeof(Amazon.SecurityLake.Model.DeleteDataLakeOrganizationConfigurationResponse))]
    [AWSCmdletOutput("None or Amazon.SecurityLake.Model.DeleteDataLakeOrganizationConfigurationResponse",
        "This cmdlet does not generate any output." +
        "The service response (type Amazon.SecurityLake.Model.DeleteDataLakeOrganizationConfigurationResponse) can be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class RemoveSLKDataLakeOrganizationConfigurationCmdlet : AmazonSecurityLakeClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter AutoEnableNewAccount
        /// <summary>
        /// <para>
        /// <para>Turns off automatic enablement of Security Lake for member accounts that are added
        /// to an organization.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public Amazon.SecurityLake.Model.DataLakeAutoEnableNewAccountConfiguration[] AutoEnableNewAccount { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The cmdlet doesn't have a return value by default.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.SecurityLake.Model.DeleteDataLakeOrganizationConfigurationResponse).
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.AutoEnableNewAccount), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Remove-SLKDataLakeOrganizationConfiguration (DeleteDataLakeOrganizationConfiguration)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.SecurityLake.Model.DeleteDataLakeOrganizationConfigurationResponse, RemoveSLKDataLakeOrganizationConfigurationCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            if (this.AutoEnableNewAccount != null)
            {
                context.AutoEnableNewAccount = new List<Amazon.SecurityLake.Model.DataLakeAutoEnableNewAccountConfiguration>(this.AutoEnableNewAccount);
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
            var request = new Amazon.SecurityLake.Model.DeleteDataLakeOrganizationConfigurationRequest();
            
            if (cmdletContext.AutoEnableNewAccount != null)
            {
                request.AutoEnableNewAccount = cmdletContext.AutoEnableNewAccount;
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
        
        private Amazon.SecurityLake.Model.DeleteDataLakeOrganizationConfigurationResponse CallAWSServiceOperation(IAmazonSecurityLake client, Amazon.SecurityLake.Model.DeleteDataLakeOrganizationConfigurationRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Security Lake", "DeleteDataLakeOrganizationConfiguration");
            try
            {
                #if DESKTOP
                return client.DeleteDataLakeOrganizationConfiguration(request);
                #elif CORECLR
                return client.DeleteDataLakeOrganizationConfigurationAsync(request).GetAwaiter().GetResult();
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
            public List<Amazon.SecurityLake.Model.DataLakeAutoEnableNewAccountConfiguration> AutoEnableNewAccount { get; set; }
            public System.Func<Amazon.SecurityLake.Model.DeleteDataLakeOrganizationConfigurationResponse, RemoveSLKDataLakeOrganizationConfigurationCmdlet, object> Select { get; set; } =
                (response, cmdlet) => null;
        }
        
    }
}
