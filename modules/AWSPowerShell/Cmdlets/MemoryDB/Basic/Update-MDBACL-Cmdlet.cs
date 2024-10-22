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
using Amazon.MemoryDB;
using Amazon.MemoryDB.Model;

namespace Amazon.PowerShell.Cmdlets.MDB
{
    /// <summary>
    /// Changes the list of users that belong to the Access Control List.
    /// </summary>
    [Cmdlet("Update", "MDBACL", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.MemoryDB.Model.ACL")]
    [AWSCmdlet("Calls the Amazon MemoryDB UpdateACL API operation.", Operation = new[] {"UpdateACL"}, SelectReturnType = typeof(Amazon.MemoryDB.Model.UpdateACLResponse))]
    [AWSCmdletOutput("Amazon.MemoryDB.Model.ACL or Amazon.MemoryDB.Model.UpdateACLResponse",
        "This cmdlet returns an Amazon.MemoryDB.Model.ACL object.",
        "The service call response (type Amazon.MemoryDB.Model.UpdateACLResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class UpdateMDBACLCmdlet : AmazonMemoryDBClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter ACLName
        /// <summary>
        /// <para>
        /// <para>The name of the Access Control List</para>
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
        public System.String ACLName { get; set; }
        #endregion
        
        #region Parameter UserNamesToAdd
        /// <summary>
        /// <para>
        /// <para>The list of users to add to the Access Control List</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String[] UserNamesToAdd { get; set; }
        #endregion
        
        #region Parameter UserNamesToRemove
        /// <summary>
        /// <para>
        /// <para>The list of users to remove from the Access Control List</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String[] UserNamesToRemove { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'ACL'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.MemoryDB.Model.UpdateACLResponse).
        /// Specifying the name of a property of type Amazon.MemoryDB.Model.UpdateACLResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "ACL";
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.ACLName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-MDBACL (UpdateACL)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.MemoryDB.Model.UpdateACLResponse, UpdateMDBACLCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.ACLName = this.ACLName;
            #if MODULAR
            if (this.ACLName == null && ParameterWasBound(nameof(this.ACLName)))
            {
                WriteWarning("You are passing $null as a value for parameter ACLName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.UserNamesToAdd != null)
            {
                context.UserNamesToAdd = new List<System.String>(this.UserNamesToAdd);
            }
            if (this.UserNamesToRemove != null)
            {
                context.UserNamesToRemove = new List<System.String>(this.UserNamesToRemove);
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
            var request = new Amazon.MemoryDB.Model.UpdateACLRequest();
            
            if (cmdletContext.ACLName != null)
            {
                request.ACLName = cmdletContext.ACLName;
            }
            if (cmdletContext.UserNamesToAdd != null)
            {
                request.UserNamesToAdd = cmdletContext.UserNamesToAdd;
            }
            if (cmdletContext.UserNamesToRemove != null)
            {
                request.UserNamesToRemove = cmdletContext.UserNamesToRemove;
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
        
        private Amazon.MemoryDB.Model.UpdateACLResponse CallAWSServiceOperation(IAmazonMemoryDB client, Amazon.MemoryDB.Model.UpdateACLRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon MemoryDB", "UpdateACL");
            try
            {
                #if DESKTOP
                return client.UpdateACL(request);
                #elif CORECLR
                return client.UpdateACLAsync(request).GetAwaiter().GetResult();
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
            public System.String ACLName { get; set; }
            public List<System.String> UserNamesToAdd { get; set; }
            public List<System.String> UserNamesToRemove { get; set; }
            public System.Func<Amazon.MemoryDB.Model.UpdateACLResponse, UpdateMDBACLCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.ACL;
        }
        
    }
}
