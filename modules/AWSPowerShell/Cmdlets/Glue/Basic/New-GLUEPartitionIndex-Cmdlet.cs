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
using Amazon.Glue;
using Amazon.Glue.Model;

namespace Amazon.PowerShell.Cmdlets.GLUE
{
    /// <summary>
    /// Creates a specified partition index in an existing table.
    /// </summary>
    [Cmdlet("New", "GLUEPartitionIndex", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("None")]
    [AWSCmdlet("Calls the AWS Glue CreatePartitionIndex API operation.", Operation = new[] {"CreatePartitionIndex"}, SelectReturnType = typeof(Amazon.Glue.Model.CreatePartitionIndexResponse))]
    [AWSCmdletOutput("None or Amazon.Glue.Model.CreatePartitionIndexResponse",
        "This cmdlet does not generate any output." +
        "The service response (type Amazon.Glue.Model.CreatePartitionIndexResponse) be returned by specifying '-Select *'."
    )]
    public partial class NewGLUEPartitionIndexCmdlet : AmazonGlueClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter CatalogId
        /// <summary>
        /// <para>
        /// <para>The catalog ID where the table resides.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String CatalogId { get; set; }
        #endregion
        
        #region Parameter DatabaseName
        /// <summary>
        /// <para>
        /// <para>Specifies the name of a database in which you want to create a partition index.</para>
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
        
        #region Parameter PartitionIndex_IndexName
        /// <summary>
        /// <para>
        /// <para>The name of the partition index.</para>
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
        public System.String PartitionIndex_IndexName { get; set; }
        #endregion
        
        #region Parameter PartitionIndex_Key
        /// <summary>
        /// <para>
        /// <para>The keys for the partition index.</para>
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
        [Alias("PartitionIndex_Keys")]
        public System.String[] PartitionIndex_Key { get; set; }
        #endregion
        
        #region Parameter TableName
        /// <summary>
        /// <para>
        /// <para>Specifies the name of a table in which you want to create a partition index.</para>
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
        public System.String TableName { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The cmdlet doesn't have a return value by default.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Glue.Model.CreatePartitionIndexResponse).
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.TableName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-GLUEPartitionIndex (CreatePartitionIndex)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Glue.Model.CreatePartitionIndexResponse, NewGLUEPartitionIndexCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.CatalogId = this.CatalogId;
            context.DatabaseName = this.DatabaseName;
            #if MODULAR
            if (this.DatabaseName == null && ParameterWasBound(nameof(this.DatabaseName)))
            {
                WriteWarning("You are passing $null as a value for parameter DatabaseName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.PartitionIndex_IndexName = this.PartitionIndex_IndexName;
            #if MODULAR
            if (this.PartitionIndex_IndexName == null && ParameterWasBound(nameof(this.PartitionIndex_IndexName)))
            {
                WriteWarning("You are passing $null as a value for parameter PartitionIndex_IndexName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.PartitionIndex_Key != null)
            {
                context.PartitionIndex_Key = new List<System.String>(this.PartitionIndex_Key);
            }
            #if MODULAR
            if (this.PartitionIndex_Key == null && ParameterWasBound(nameof(this.PartitionIndex_Key)))
            {
                WriteWarning("You are passing $null as a value for parameter PartitionIndex_Key which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.TableName = this.TableName;
            #if MODULAR
            if (this.TableName == null && ParameterWasBound(nameof(this.TableName)))
            {
                WriteWarning("You are passing $null as a value for parameter TableName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.Glue.Model.CreatePartitionIndexRequest();
            
            if (cmdletContext.CatalogId != null)
            {
                request.CatalogId = cmdletContext.CatalogId;
            }
            if (cmdletContext.DatabaseName != null)
            {
                request.DatabaseName = cmdletContext.DatabaseName;
            }
            
             // populate PartitionIndex
            var requestPartitionIndexIsNull = true;
            request.PartitionIndex = new Amazon.Glue.Model.PartitionIndex();
            System.String requestPartitionIndex_partitionIndex_IndexName = null;
            if (cmdletContext.PartitionIndex_IndexName != null)
            {
                requestPartitionIndex_partitionIndex_IndexName = cmdletContext.PartitionIndex_IndexName;
            }
            if (requestPartitionIndex_partitionIndex_IndexName != null)
            {
                request.PartitionIndex.IndexName = requestPartitionIndex_partitionIndex_IndexName;
                requestPartitionIndexIsNull = false;
            }
            List<System.String> requestPartitionIndex_partitionIndex_Key = null;
            if (cmdletContext.PartitionIndex_Key != null)
            {
                requestPartitionIndex_partitionIndex_Key = cmdletContext.PartitionIndex_Key;
            }
            if (requestPartitionIndex_partitionIndex_Key != null)
            {
                request.PartitionIndex.Keys = requestPartitionIndex_partitionIndex_Key;
                requestPartitionIndexIsNull = false;
            }
             // determine if request.PartitionIndex should be set to null
            if (requestPartitionIndexIsNull)
            {
                request.PartitionIndex = null;
            }
            if (cmdletContext.TableName != null)
            {
                request.TableName = cmdletContext.TableName;
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
        
        private Amazon.Glue.Model.CreatePartitionIndexResponse CallAWSServiceOperation(IAmazonGlue client, Amazon.Glue.Model.CreatePartitionIndexRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Glue", "CreatePartitionIndex");
            try
            {
                #if DESKTOP
                return client.CreatePartitionIndex(request);
                #elif CORECLR
                return client.CreatePartitionIndexAsync(request).GetAwaiter().GetResult();
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
            public System.String PartitionIndex_IndexName { get; set; }
            public List<System.String> PartitionIndex_Key { get; set; }
            public System.String TableName { get; set; }
            public System.Func<Amazon.Glue.Model.CreatePartitionIndexResponse, NewGLUEPartitionIndexCmdlet, object> Select { get; set; } =
                (response, cmdlet) => null;
        }
        
    }
}
