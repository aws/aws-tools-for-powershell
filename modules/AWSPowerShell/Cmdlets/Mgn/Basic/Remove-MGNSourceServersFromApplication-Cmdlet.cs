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
using Amazon.Mgn;
using Amazon.Mgn.Model;

namespace Amazon.PowerShell.Cmdlets.MGN
{
    /// <summary>
    /// Disassociate source servers from application.
    /// </summary>
    [Cmdlet("Remove", "MGNSourceServersFromApplication", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.High)]
    [OutputType("None")]
    [AWSCmdlet("Calls the Application Migration Service DisassociateSourceServers API operation.", Operation = new[] {"DisassociateSourceServers"}, SelectReturnType = typeof(Amazon.Mgn.Model.DisassociateSourceServersResponse))]
    [AWSCmdletOutput("None or Amazon.Mgn.Model.DisassociateSourceServersResponse",
        "This cmdlet does not generate any output." +
        "The service response (type Amazon.Mgn.Model.DisassociateSourceServersResponse) be returned by specifying '-Select *'."
    )]
    public partial class RemoveMGNSourceServersFromApplicationCmdlet : AmazonMgnClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter AccountID
        /// <summary>
        /// <para>
        /// <para>Account ID.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String AccountID { get; set; }
        #endregion
        
        #region Parameter ApplicationID
        /// <summary>
        /// <para>
        /// <para>Application ID.</para>
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
        public System.String ApplicationID { get; set; }
        #endregion
        
        #region Parameter SourceServerIDs
        /// <summary>
        /// <para>
        /// <para>Source server IDs list.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyCollection]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.String[] SourceServerIDs { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The cmdlet doesn't have a return value by default.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Mgn.Model.DisassociateSourceServersResponse).
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the ApplicationID parameter.
        /// The -PassThru parameter is deprecated, use -Select '^ApplicationID' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^ApplicationID' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.ApplicationID), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Remove-MGNSourceServersFromApplication (DisassociateSourceServers)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Mgn.Model.DisassociateSourceServersResponse, RemoveMGNSourceServersFromApplicationCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.ApplicationID;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.AccountID = this.AccountID;
            context.ApplicationID = this.ApplicationID;
            #if MODULAR
            if (this.ApplicationID == null && ParameterWasBound(nameof(this.ApplicationID)))
            {
                WriteWarning("You are passing $null as a value for parameter ApplicationID which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.SourceServerIDs != null)
            {
                context.SourceServerIDs = new List<System.String>(this.SourceServerIDs);
            }
            #if MODULAR
            if (this.SourceServerIDs == null && ParameterWasBound(nameof(this.SourceServerIDs)))
            {
                WriteWarning("You are passing $null as a value for parameter SourceServerIDs which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.Mgn.Model.DisassociateSourceServersRequest();
            
            if (cmdletContext.AccountID != null)
            {
                request.AccountID = cmdletContext.AccountID;
            }
            if (cmdletContext.ApplicationID != null)
            {
                request.ApplicationID = cmdletContext.ApplicationID;
            }
            if (cmdletContext.SourceServerIDs != null)
            {
                request.SourceServerIDs = cmdletContext.SourceServerIDs;
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
        
        private Amazon.Mgn.Model.DisassociateSourceServersResponse CallAWSServiceOperation(IAmazonMgn client, Amazon.Mgn.Model.DisassociateSourceServersRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Application Migration Service", "DisassociateSourceServers");
            try
            {
                #if DESKTOP
                return client.DisassociateSourceServers(request);
                #elif CORECLR
                return client.DisassociateSourceServersAsync(request).GetAwaiter().GetResult();
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
            public System.String AccountID { get; set; }
            public System.String ApplicationID { get; set; }
            public List<System.String> SourceServerIDs { get; set; }
            public System.Func<Amazon.Mgn.Model.DisassociateSourceServersResponse, RemoveMGNSourceServersFromApplicationCmdlet, object> Select { get; set; } =
                (response, cmdlet) => null;
        }
        
    }
}
