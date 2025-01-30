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
using Amazon.Glue;
using Amazon.Glue.Model;

namespace Amazon.PowerShell.Cmdlets.GLUE
{
    /// <summary>
    /// Deletes multiple tables at once.
    /// 
    ///  <note><para>
    /// After completing this operation, you no longer have access to the table versions and
    /// partitions that belong to the deleted table. Glue deletes these "orphaned" resources
    /// asynchronously in a timely manner, at the discretion of the service.
    /// </para><para>
    /// To ensure the immediate deletion of all related resources, before calling <c>BatchDeleteTable</c>,
    /// use <c>DeleteTableVersion</c> or <c>BatchDeleteTableVersion</c>, and <c>DeletePartition</c>
    /// or <c>BatchDeletePartition</c>, to delete any resources that belong to the table.
    /// </para></note>
    /// </summary>
    [Cmdlet("Remove", "GLUETableBatch", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.High)]
    [OutputType("Amazon.Glue.Model.TableError")]
    [AWSCmdlet("Calls the AWS Glue BatchDeleteTable API operation.", Operation = new[] {"BatchDeleteTable"}, SelectReturnType = typeof(Amazon.Glue.Model.BatchDeleteTableResponse))]
    [AWSCmdletOutput("Amazon.Glue.Model.TableError or Amazon.Glue.Model.BatchDeleteTableResponse",
        "This cmdlet returns a collection of Amazon.Glue.Model.TableError objects.",
        "The service call response (type Amazon.Glue.Model.BatchDeleteTableResponse) can be returned by specifying '-Select *'."
    )]
    public partial class RemoveGLUETableBatchCmdlet : AmazonGlueClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter CatalogId
        /// <summary>
        /// <para>
        /// <para>The ID of the Data Catalog where the table resides. If none is provided, the Amazon
        /// Web Services account ID is used by default.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String CatalogId { get; set; }
        #endregion
        
        #region Parameter DatabaseName
        /// <summary>
        /// <para>
        /// <para>The name of the catalog database in which the tables to delete reside. For Hive compatibility,
        /// this name is entirely lowercase.</para>
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
        public System.String DatabaseName { get; set; }
        #endregion
        
        #region Parameter TablesToDelete
        /// <summary>
        /// <para>
        /// <para>A list of the table to delete.</para>
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
        public System.String[] TablesToDelete { get; set; }
        #endregion
        
        #region Parameter TransactionId
        /// <summary>
        /// <para>
        /// <para>The transaction ID at which to delete the table contents.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String TransactionId { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'Errors'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Glue.Model.BatchDeleteTableResponse).
        /// Specifying the name of a property of type Amazon.Glue.Model.BatchDeleteTableResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "Errors";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the TablesToDelete parameter.
        /// The -PassThru parameter is deprecated, use -Select '^TablesToDelete' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^TablesToDelete' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.DatabaseName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Remove-GLUETableBatch (BatchDeleteTable)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Glue.Model.BatchDeleteTableResponse, RemoveGLUETableBatchCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.TablesToDelete;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.CatalogId = this.CatalogId;
            context.DatabaseName = this.DatabaseName;
            #if MODULAR
            if (this.DatabaseName == null && ParameterWasBound(nameof(this.DatabaseName)))
            {
                WriteWarning("You are passing $null as a value for parameter DatabaseName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.TablesToDelete != null)
            {
                context.TablesToDelete = new List<System.String>(this.TablesToDelete);
            }
            #if MODULAR
            if (this.TablesToDelete == null && ParameterWasBound(nameof(this.TablesToDelete)))
            {
                WriteWarning("You are passing $null as a value for parameter TablesToDelete which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.TransactionId = this.TransactionId;
            
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
            var request = new Amazon.Glue.Model.BatchDeleteTableRequest();
            
            if (cmdletContext.CatalogId != null)
            {
                request.CatalogId = cmdletContext.CatalogId;
            }
            if (cmdletContext.DatabaseName != null)
            {
                request.DatabaseName = cmdletContext.DatabaseName;
            }
            if (cmdletContext.TablesToDelete != null)
            {
                request.TablesToDelete = cmdletContext.TablesToDelete;
            }
            if (cmdletContext.TransactionId != null)
            {
                request.TransactionId = cmdletContext.TransactionId;
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
        
        private Amazon.Glue.Model.BatchDeleteTableResponse CallAWSServiceOperation(IAmazonGlue client, Amazon.Glue.Model.BatchDeleteTableRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Glue", "BatchDeleteTable");
            try
            {
                #if DESKTOP
                return client.BatchDeleteTable(request);
                #elif CORECLR
                return client.BatchDeleteTableAsync(request).GetAwaiter().GetResult();
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
            public System.String CatalogId { get; set; }
            public System.String DatabaseName { get; set; }
            public List<System.String> TablesToDelete { get; set; }
            public System.String TransactionId { get; set; }
            public System.Func<Amazon.Glue.Model.BatchDeleteTableResponse, RemoveGLUETableBatchCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.Errors;
        }
        
    }
}
