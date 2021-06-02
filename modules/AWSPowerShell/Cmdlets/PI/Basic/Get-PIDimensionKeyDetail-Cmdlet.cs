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
using Amazon.PI;
using Amazon.PI.Model;

namespace Amazon.PowerShell.Cmdlets.PI
{
    /// <summary>
    /// Get the attributes of the specified dimension group for a DB instance or data source.
    /// For example, if you specify a SQL ID, <code>GetDimensionKeyDetails</code> retrieves
    /// the full text of the dimension <code>db.sql.statement</code> associated with this
    /// ID. This operation is useful because <code>GetResourceMetrics</code> and <code>DescribeDimensionKeys</code>
    /// don't support retrieval of large SQL statement text.
    /// </summary>
    [Cmdlet("Get", "PIDimensionKeyDetail")]
    [OutputType("Amazon.PI.Model.GetDimensionKeyDetailsResponse")]
    [AWSCmdlet("Calls the AWS Performance Insights GetDimensionKeyDetails API operation.", Operation = new[] {"GetDimensionKeyDetails"}, SelectReturnType = typeof(Amazon.PI.Model.GetDimensionKeyDetailsResponse))]
    [AWSCmdletOutput("Amazon.PI.Model.GetDimensionKeyDetailsResponse",
        "This cmdlet returns an Amazon.PI.Model.GetDimensionKeyDetailsResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class GetPIDimensionKeyDetailCmdlet : AmazonPIClientCmdlet, IExecutor
    {
        
        #region Parameter Group
        /// <summary>
        /// <para>
        /// <para>The name of the dimension group. The only valid value is <code>db.sql</code>. Performance
        /// Insights searches the specified group for the dimension group ID.</para>
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
        public System.String Group { get; set; }
        #endregion
        
        #region Parameter GroupIdentifier
        /// <summary>
        /// <para>
        /// <para>The ID of the dimension group from which to retrieve dimension details. For dimension
        /// group <code>db.sql</code>, the group ID is <code>db.sql.id</code>.</para>
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
        public System.String GroupIdentifier { get; set; }
        #endregion
        
        #region Parameter Identifier
        /// <summary>
        /// <para>
        /// <para>The ID for a data source from which to gather dimension data. This ID must be immutable
        /// and unique within an AWS Region. When a DB instance is the data source, specify its
        /// <code>DbiResourceId</code> value. For example, specify <code>db-ABCDEFGHIJKLMNOPQRSTU1VW2X</code>.
        /// </para>
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
        public System.String Identifier { get; set; }
        #endregion
        
        #region Parameter RequestedDimension
        /// <summary>
        /// <para>
        /// <para>A list of dimensions to retrieve the detail data for within the given dimension group.
        /// For the dimension group <code>db.sql</code>, specify either the full dimension name
        /// <code>db.sql.statement</code> or the short dimension name <code>statement</code>.
        /// If you don't specify this parameter, Performance Insights returns all dimension data
        /// within the specified dimension group.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("RequestedDimensions")]
        public System.String[] RequestedDimension { get; set; }
        #endregion
        
        #region Parameter ServiceType
        /// <summary>
        /// <para>
        /// <para>The AWS service for which Performance Insights returns data. The only valid value
        /// is <code>RDS</code>.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.PI.ServiceType")]
        public Amazon.PI.ServiceType ServiceType { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.PI.Model.GetDimensionKeyDetailsResponse).
        /// Specifying the name of a property of type Amazon.PI.Model.GetDimensionKeyDetailsResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.PI.Model.GetDimensionKeyDetailsResponse, GetPIDimensionKeyDetailCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.Group = this.Group;
            #if MODULAR
            if (this.Group == null && ParameterWasBound(nameof(this.Group)))
            {
                WriteWarning("You are passing $null as a value for parameter Group which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.GroupIdentifier = this.GroupIdentifier;
            #if MODULAR
            if (this.GroupIdentifier == null && ParameterWasBound(nameof(this.GroupIdentifier)))
            {
                WriteWarning("You are passing $null as a value for parameter GroupIdentifier which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Identifier = this.Identifier;
            #if MODULAR
            if (this.Identifier == null && ParameterWasBound(nameof(this.Identifier)))
            {
                WriteWarning("You are passing $null as a value for parameter Identifier which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.RequestedDimension != null)
            {
                context.RequestedDimension = new List<System.String>(this.RequestedDimension);
            }
            context.ServiceType = this.ServiceType;
            #if MODULAR
            if (this.ServiceType == null && ParameterWasBound(nameof(this.ServiceType)))
            {
                WriteWarning("You are passing $null as a value for parameter ServiceType which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.PI.Model.GetDimensionKeyDetailsRequest();
            
            if (cmdletContext.Group != null)
            {
                request.Group = cmdletContext.Group;
            }
            if (cmdletContext.GroupIdentifier != null)
            {
                request.GroupIdentifier = cmdletContext.GroupIdentifier;
            }
            if (cmdletContext.Identifier != null)
            {
                request.Identifier = cmdletContext.Identifier;
            }
            if (cmdletContext.RequestedDimension != null)
            {
                request.RequestedDimensions = cmdletContext.RequestedDimension;
            }
            if (cmdletContext.ServiceType != null)
            {
                request.ServiceType = cmdletContext.ServiceType;
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
        
        private Amazon.PI.Model.GetDimensionKeyDetailsResponse CallAWSServiceOperation(IAmazonPI client, Amazon.PI.Model.GetDimensionKeyDetailsRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Performance Insights", "GetDimensionKeyDetails");
            try
            {
                #if DESKTOP
                return client.GetDimensionKeyDetails(request);
                #elif CORECLR
                return client.GetDimensionKeyDetailsAsync(request).GetAwaiter().GetResult();
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
            public System.String Group { get; set; }
            public System.String GroupIdentifier { get; set; }
            public System.String Identifier { get; set; }
            public List<System.String> RequestedDimension { get; set; }
            public Amazon.PI.ServiceType ServiceType { get; set; }
            public System.Func<Amazon.PI.Model.GetDimensionKeyDetailsResponse, GetPIDimensionKeyDetailCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
