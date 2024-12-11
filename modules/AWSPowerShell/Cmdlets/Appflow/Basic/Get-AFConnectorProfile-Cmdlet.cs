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
using Amazon.Appflow;
using Amazon.Appflow.Model;

namespace Amazon.PowerShell.Cmdlets.AF
{
    /// <summary>
    /// Returns a list of <c>connector-profile</c> details matching the provided <c>connector-profile</c>
    /// names and <c>connector-types</c>. Both input lists are optional, and you can use them
    /// to filter the result. 
    /// 
    ///  
    /// <para>
    /// If no names or <c>connector-types</c> are provided, returns all connector profiles
    /// in a paginated form. If there is no match, this operation returns an empty list.
    /// </para>
    /// </summary>
    [Cmdlet("Get", "AFConnectorProfile")]
    [OutputType("Amazon.Appflow.Model.ConnectorProfile")]
    [AWSCmdlet("Calls the Amazon Appflow DescribeConnectorProfiles API operation.", Operation = new[] {"DescribeConnectorProfiles"}, SelectReturnType = typeof(Amazon.Appflow.Model.DescribeConnectorProfilesResponse))]
    [AWSCmdletOutput("Amazon.Appflow.Model.ConnectorProfile or Amazon.Appflow.Model.DescribeConnectorProfilesResponse",
        "This cmdlet returns a collection of Amazon.Appflow.Model.ConnectorProfile objects.",
        "The service call response (type Amazon.Appflow.Model.DescribeConnectorProfilesResponse) can be returned by specifying '-Select *'."
    )]
    public partial class GetAFConnectorProfileCmdlet : AmazonAppflowClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter ConnectorLabel
        /// <summary>
        /// <para>
        /// <para>The name of the connector. The name is unique for each <c>ConnectorRegistration</c>
        /// in your Amazon Web Services account. Only needed if calling for CUSTOMCONNECTOR connector
        /// type/.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ConnectorLabel { get; set; }
        #endregion
        
        #region Parameter ConnectorProfileName
        /// <summary>
        /// <para>
        /// <para> The name of the connector profile. The name is unique for each <c>ConnectorProfile</c>
        /// in the Amazon Web Services account. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ConnectorProfileNames")]
        public System.String[] ConnectorProfileName { get; set; }
        #endregion
        
        #region Parameter ConnectorType
        /// <summary>
        /// <para>
        /// <para> The type of connector, such as Salesforce, Amplitude, and so on. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        [AWSConstantClassSource("Amazon.Appflow.ConnectorType")]
        public Amazon.Appflow.ConnectorType ConnectorType { get; set; }
        #endregion
        
        #region Parameter MaxResult
        /// <summary>
        /// <para>
        /// <para> Specifies the maximum number of items that should be returned in the result set.
        /// The default for <c>maxResults</c> is 20 (for all paginated API operations). </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MaxResults")]
        public System.Int32? MaxResult { get; set; }
        #endregion
        
        #region Parameter NextToken
        /// <summary>
        /// <para>
        /// <para> The pagination token for the next page of data. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String NextToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'ConnectorProfileDetails'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Appflow.Model.DescribeConnectorProfilesResponse).
        /// Specifying the name of a property of type Amazon.Appflow.Model.DescribeConnectorProfilesResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "ConnectorProfileDetails";
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
                context.Select = CreateSelectDelegate<Amazon.Appflow.Model.DescribeConnectorProfilesResponse, GetAFConnectorProfileCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.ConnectorLabel = this.ConnectorLabel;
            if (this.ConnectorProfileName != null)
            {
                context.ConnectorProfileName = new List<System.String>(this.ConnectorProfileName);
            }
            context.ConnectorType = this.ConnectorType;
            context.MaxResult = this.MaxResult;
            context.NextToken = this.NextToken;
            
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
            var request = new Amazon.Appflow.Model.DescribeConnectorProfilesRequest();
            
            if (cmdletContext.ConnectorLabel != null)
            {
                request.ConnectorLabel = cmdletContext.ConnectorLabel;
            }
            if (cmdletContext.ConnectorProfileName != null)
            {
                request.ConnectorProfileNames = cmdletContext.ConnectorProfileName;
            }
            if (cmdletContext.ConnectorType != null)
            {
                request.ConnectorType = cmdletContext.ConnectorType;
            }
            if (cmdletContext.MaxResult != null)
            {
                request.MaxResults = cmdletContext.MaxResult.Value;
            }
            if (cmdletContext.NextToken != null)
            {
                request.NextToken = cmdletContext.NextToken;
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
        
        private Amazon.Appflow.Model.DescribeConnectorProfilesResponse CallAWSServiceOperation(IAmazonAppflow client, Amazon.Appflow.Model.DescribeConnectorProfilesRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Appflow", "DescribeConnectorProfiles");
            try
            {
                #if DESKTOP
                return client.DescribeConnectorProfiles(request);
                #elif CORECLR
                return client.DescribeConnectorProfilesAsync(request).GetAwaiter().GetResult();
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
            public System.String ConnectorLabel { get; set; }
            public List<System.String> ConnectorProfileName { get; set; }
            public Amazon.Appflow.ConnectorType ConnectorType { get; set; }
            public System.Int32? MaxResult { get; set; }
            public System.String NextToken { get; set; }
            public System.Func<Amazon.Appflow.Model.DescribeConnectorProfilesResponse, GetAFConnectorProfileCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.ConnectorProfileDetails;
        }
        
    }
}
