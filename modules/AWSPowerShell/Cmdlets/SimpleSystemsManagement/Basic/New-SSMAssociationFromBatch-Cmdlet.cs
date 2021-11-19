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
using Amazon.SimpleSystemsManagement;
using Amazon.SimpleSystemsManagement.Model;

namespace Amazon.PowerShell.Cmdlets.SSM
{
    /// <summary>
    /// Associates the specified Amazon Web Services Systems Manager document (SSM document)
    /// with the specified managed nodes or targets.
    /// 
    ///  
    /// <para>
    /// When you associate a document with one or more managed nodes using IDs or tags, Amazon
    /// Web Services Systems Manager Agent (SSM Agent) running on the managed node processes
    /// the document and configures the node as specified.
    /// </para><para>
    /// If you associate a document with a managed node that already has an associated document,
    /// the system returns the AssociationAlreadyExists exception.
    /// </para>
    /// </summary>
    [Cmdlet("New", "SSMAssociationFromBatch", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.SimpleSystemsManagement.Model.CreateAssociationBatchResponse")]
    [AWSCmdlet("Calls the AWS Systems Manager CreateAssociationBatch API operation.", Operation = new[] {"CreateAssociationBatch"}, SelectReturnType = typeof(Amazon.SimpleSystemsManagement.Model.CreateAssociationBatchResponse))]
    [AWSCmdletOutput("Amazon.SimpleSystemsManagement.Model.CreateAssociationBatchResponse",
        "This cmdlet returns an Amazon.SimpleSystemsManagement.Model.CreateAssociationBatchResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class NewSSMAssociationFromBatchCmdlet : AmazonSimpleSystemsManagementClientCmdlet, IExecutor
    {
        
        #region Parameter Entry
        /// <summary>
        /// <para>
        /// <para>One or more associations.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        #else
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyCollection]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [Alias("Entries")]
        public Amazon.SimpleSystemsManagement.Model.CreateAssociationBatchRequestEntry[] Entry { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.SimpleSystemsManagement.Model.CreateAssociationBatchResponse).
        /// Specifying the name of a property of type Amazon.SimpleSystemsManagement.Model.CreateAssociationBatchResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the Entry parameter.
        /// The -PassThru parameter is deprecated, use -Select '^Entry' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^Entry' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.Entry), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-SSMAssociationFromBatch (CreateAssociationBatch)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.SimpleSystemsManagement.Model.CreateAssociationBatchResponse, NewSSMAssociationFromBatchCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.Entry;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (this.Entry != null)
            {
                context.Entry = new List<Amazon.SimpleSystemsManagement.Model.CreateAssociationBatchRequestEntry>(this.Entry);
            }
            #if MODULAR
            if (this.Entry == null && ParameterWasBound(nameof(this.Entry)))
            {
                WriteWarning("You are passing $null as a value for parameter Entry which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.SimpleSystemsManagement.Model.CreateAssociationBatchRequest();
            
            if (cmdletContext.Entry != null)
            {
                request.Entries = cmdletContext.Entry;
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
        
        private Amazon.SimpleSystemsManagement.Model.CreateAssociationBatchResponse CallAWSServiceOperation(IAmazonSimpleSystemsManagement client, Amazon.SimpleSystemsManagement.Model.CreateAssociationBatchRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Systems Manager", "CreateAssociationBatch");
            try
            {
                #if DESKTOP
                return client.CreateAssociationBatch(request);
                #elif CORECLR
                return client.CreateAssociationBatchAsync(request).GetAwaiter().GetResult();
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
            public List<Amazon.SimpleSystemsManagement.Model.CreateAssociationBatchRequestEntry> Entry { get; set; }
            public System.Func<Amazon.SimpleSystemsManagement.Model.CreateAssociationBatchResponse, NewSSMAssociationFromBatchCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
