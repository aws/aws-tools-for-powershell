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
using Amazon.RDS;
using Amazon.RDS.Model;

namespace Amazon.PowerShell.Cmdlets.RDS
{
    /// <summary>
    /// Returns a list of DB snapshot attribute names and values for a manual DB snapshot.
    /// 
    ///  
    /// <para>
    /// When sharing snapshots with other Amazon Web Services accounts, <c>DescribeDBSnapshotAttributes</c>
    /// returns the <c>restore</c> attribute and a list of IDs for the Amazon Web Services
    /// accounts that are authorized to copy or restore the manual DB snapshot. If <c>all</c>
    /// is included in the list of values for the <c>restore</c> attribute, then the manual
    /// DB snapshot is public and can be copied or restored by all Amazon Web Services accounts.
    /// </para><para>
    /// To add or remove access for an Amazon Web Services account to copy or restore a manual
    /// DB snapshot, or to make the manual DB snapshot public or private, use the <c>ModifyDBSnapshotAttribute</c>
    /// API action.
    /// </para>
    /// </summary>
    [Cmdlet("Get", "RDSDBSnapshotAttribute")]
    [OutputType("Amazon.RDS.Model.DBSnapshotAttributesResult")]
    [AWSCmdlet("Calls the Amazon Relational Database Service DescribeDBSnapshotAttributes API operation.", Operation = new[] {"DescribeDBSnapshotAttributes"}, SelectReturnType = typeof(Amazon.RDS.Model.DescribeDBSnapshotAttributesResponse), LegacyAlias="Get-RDSDBSnapshotAttributes")]
    [AWSCmdletOutput("Amazon.RDS.Model.DBSnapshotAttributesResult or Amazon.RDS.Model.DescribeDBSnapshotAttributesResponse",
        "This cmdlet returns an Amazon.RDS.Model.DBSnapshotAttributesResult object.",
        "The service call response (type Amazon.RDS.Model.DescribeDBSnapshotAttributesResponse) can be returned by specifying '-Select *'."
    )]
    public partial class GetRDSDBSnapshotAttributeCmdlet : AmazonRDSClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter DBSnapshotIdentifier
        /// <summary>
        /// <para>
        /// <para>The identifier for the DB snapshot to describe the attributes for.</para>
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
        public System.String DBSnapshotIdentifier { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'DBSnapshotAttributesResult'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.RDS.Model.DescribeDBSnapshotAttributesResponse).
        /// Specifying the name of a property of type Amazon.RDS.Model.DescribeDBSnapshotAttributesResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "DBSnapshotAttributesResult";
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
                context.Select = CreateSelectDelegate<Amazon.RDS.Model.DescribeDBSnapshotAttributesResponse, GetRDSDBSnapshotAttributeCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.DBSnapshotIdentifier = this.DBSnapshotIdentifier;
            #if MODULAR
            if (this.DBSnapshotIdentifier == null && ParameterWasBound(nameof(this.DBSnapshotIdentifier)))
            {
                WriteWarning("You are passing $null as a value for parameter DBSnapshotIdentifier which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.RDS.Model.DescribeDBSnapshotAttributesRequest();
            
            if (cmdletContext.DBSnapshotIdentifier != null)
            {
                request.DBSnapshotIdentifier = cmdletContext.DBSnapshotIdentifier;
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
        
        private Amazon.RDS.Model.DescribeDBSnapshotAttributesResponse CallAWSServiceOperation(IAmazonRDS client, Amazon.RDS.Model.DescribeDBSnapshotAttributesRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Relational Database Service", "DescribeDBSnapshotAttributes");
            try
            {
                #if DESKTOP
                return client.DescribeDBSnapshotAttributes(request);
                #elif CORECLR
                return client.DescribeDBSnapshotAttributesAsync(request).GetAwaiter().GetResult();
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
            public System.String DBSnapshotIdentifier { get; set; }
            public System.Func<Amazon.RDS.Model.DescribeDBSnapshotAttributesResponse, GetRDSDBSnapshotAttributeCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.DBSnapshotAttributesResult;
        }
        
    }
}
