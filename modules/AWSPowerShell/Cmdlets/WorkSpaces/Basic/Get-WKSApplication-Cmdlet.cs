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
using Amazon.WorkSpaces;
using Amazon.WorkSpaces.Model;

namespace Amazon.PowerShell.Cmdlets.WKS
{
    /// <summary>
    /// Describes the specified applications by filtering based on their compute types, license
    /// availability, operating systems, and owners.<br/><br/>This cmdlet automatically pages all available results to the pipeline - parameters related to iteration are only needed if you want to manually control the paginated output. To disable autopagination, use -NoAutoIteration.
    /// </summary>
    [Cmdlet("Get", "WKSApplication")]
    [OutputType("Amazon.WorkSpaces.Model.WorkSpaceApplication")]
    [AWSCmdlet("Calls the Amazon WorkSpaces DescribeApplications API operation.", Operation = new[] {"DescribeApplications"}, SelectReturnType = typeof(Amazon.WorkSpaces.Model.DescribeApplicationsResponse))]
    [AWSCmdletOutput("Amazon.WorkSpaces.Model.WorkSpaceApplication or Amazon.WorkSpaces.Model.DescribeApplicationsResponse",
        "This cmdlet returns a collection of Amazon.WorkSpaces.Model.WorkSpaceApplication objects.",
        "The service call response (type Amazon.WorkSpaces.Model.DescribeApplicationsResponse) can be returned by specifying '-Select *'."
    )]
    public partial class GetWKSApplicationCmdlet : AmazonWorkSpacesClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter ApplicationId
        /// <summary>
        /// <para>
        /// <para>The identifiers of one or more applications.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ApplicationIds")]
        public System.String[] ApplicationId { get; set; }
        #endregion
        
        #region Parameter ComputeTypeName
        /// <summary>
        /// <para>
        /// <para>The compute types supported by the applications.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ComputeTypeNames")]
        public System.String[] ComputeTypeName { get; set; }
        #endregion
        
        #region Parameter LicenseType
        /// <summary>
        /// <para>
        /// <para>The license availability for the applications.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        [AWSConstantClassSource("Amazon.WorkSpaces.WorkSpaceApplicationLicenseType")]
        public Amazon.WorkSpaces.WorkSpaceApplicationLicenseType LicenseType { get; set; }
        #endregion
        
        #region Parameter OperatingSystemName
        /// <summary>
        /// <para>
        /// <para>The operating systems supported by the applications.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("OperatingSystemNames")]
        public System.String[] OperatingSystemName { get; set; }
        #endregion
        
        #region Parameter MaxResult
        /// <summary>
        /// <para>
        /// <para>The maximum number of applications to return.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MaxResults")]
        public System.Int32? MaxResult { get; set; }
        #endregion
        
        #region Parameter NextToken
        /// <summary>
        /// <para>
        /// <para>If you received a <c>NextToken</c> from a previous call that was paginated, provide
        /// this token to receive the next set of results.</para>
        /// </para>
        /// <para>
        /// <br/><b>Note:</b> This parameter is only used if you are manually controlling output pagination of the service API call.
        /// <br/>'NextToken' is only returned by the cmdlet when '-Select *' is specified. In order to manually control output pagination, set '-NextToken' to null for the first call then set the 'NextToken' using the same property output from the previous call for subsequent calls.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String NextToken { get; set; }
        #endregion
        
        #region Parameter Owner
        /// <summary>
        /// <para>
        /// <para>The owner of the applications.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Owner { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'Applications'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.WorkSpaces.Model.DescribeApplicationsResponse).
        /// Specifying the name of a property of type Amazon.WorkSpaces.Model.DescribeApplicationsResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "Applications";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the LicenseType parameter.
        /// The -PassThru parameter is deprecated, use -Select '^LicenseType' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^LicenseType' instead. This parameter will be removed in a future version.")]
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public SwitchParameter PassThru { get; set; }
        #endregion
        
        #region Parameter NoAutoIteration
        /// <summary>
        /// By default the cmdlet will auto-iterate and retrieve all results to the pipeline by performing multiple
        /// service calls. If set, the cmdlet will retrieve only the next 'page' of results using the value of NextToken
        /// as the start point.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public SwitchParameter NoAutoIteration { get; set; }
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
                context.Select = CreateSelectDelegate<Amazon.WorkSpaces.Model.DescribeApplicationsResponse, GetWKSApplicationCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.LicenseType;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (this.ApplicationId != null)
            {
                context.ApplicationId = new List<System.String>(this.ApplicationId);
            }
            if (this.ComputeTypeName != null)
            {
                context.ComputeTypeName = new List<System.String>(this.ComputeTypeName);
            }
            context.LicenseType = this.LicenseType;
            context.MaxResult = this.MaxResult;
            context.NextToken = this.NextToken;
            if (this.OperatingSystemName != null)
            {
                context.OperatingSystemName = new List<System.String>(this.OperatingSystemName);
            }
            context.Owner = this.Owner;
            
            // allow further manipulation of loaded context prior to processing
            PostExecutionContextLoad(context);
            
            var output = Execute(context) as CmdletOutput;
            ProcessOutput(output);
        }
        
        #region IExecutor Members
        
        public object Execute(ExecutorContext context)
        {
            var cmdletContext = context as CmdletContext;
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            var useParameterSelect = this.Select.StartsWith("^") || this.PassThru.IsPresent;
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            
            // create request and set iteration invariants
            var request = new Amazon.WorkSpaces.Model.DescribeApplicationsRequest();
            
            if (cmdletContext.ApplicationId != null)
            {
                request.ApplicationIds = cmdletContext.ApplicationId;
            }
            if (cmdletContext.ComputeTypeName != null)
            {
                request.ComputeTypeNames = cmdletContext.ComputeTypeName;
            }
            if (cmdletContext.LicenseType != null)
            {
                request.LicenseType = cmdletContext.LicenseType;
            }
            if (cmdletContext.MaxResult != null)
            {
                request.MaxResults = cmdletContext.MaxResult.Value;
            }
            if (cmdletContext.OperatingSystemName != null)
            {
                request.OperatingSystemNames = cmdletContext.OperatingSystemName;
            }
            if (cmdletContext.Owner != null)
            {
                request.Owner = cmdletContext.Owner;
            }
            
            // Initialize loop variant and commence piping
            var _nextToken = cmdletContext.NextToken;
            var _userControllingPaging = this.NoAutoIteration.IsPresent || ParameterWasBound(nameof(this.NextToken));
            
            var client = Client ?? CreateClient(_CurrentCredentials, _RegionEndpoint);
            do
            {
                request.NextToken = _nextToken;
                
                CmdletOutput output;
                
                try
                {
                    
                    var response = CallAWSServiceOperation(client, request);
                    
                    object pipelineOutput = null;
                    if (!useParameterSelect)
                    {
                        pipelineOutput = cmdletContext.Select(response, this);
                    }
                    output = new CmdletOutput
                    {
                        PipelineOutput = pipelineOutput,
                        ServiceResponse = response
                    };
                    
                    _nextToken = response.NextToken;
                }
                catch (Exception e)
                {
                    output = new CmdletOutput { ErrorResponse = e };
                }
                
                ProcessOutput(output);
                
            } while (!_userControllingPaging && AutoIterationHelpers.HasValue(_nextToken));
            
            if (useParameterSelect)
            {
                WriteObject(cmdletContext.Select(null, this));
            }
            
            
            return null;
        }
        
        public ExecutorContext CreateContext()
        {
            return new CmdletContext();
        }
        
        #endregion
        
        #region AWS Service Operation Call
        
        private Amazon.WorkSpaces.Model.DescribeApplicationsResponse CallAWSServiceOperation(IAmazonWorkSpaces client, Amazon.WorkSpaces.Model.DescribeApplicationsRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon WorkSpaces", "DescribeApplications");
            try
            {
                #if DESKTOP
                return client.DescribeApplications(request);
                #elif CORECLR
                return client.DescribeApplicationsAsync(request).GetAwaiter().GetResult();
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
            public List<System.String> ApplicationId { get; set; }
            public List<System.String> ComputeTypeName { get; set; }
            public Amazon.WorkSpaces.WorkSpaceApplicationLicenseType LicenseType { get; set; }
            public System.Int32? MaxResult { get; set; }
            public System.String NextToken { get; set; }
            public List<System.String> OperatingSystemName { get; set; }
            public System.String Owner { get; set; }
            public System.Func<Amazon.WorkSpaces.Model.DescribeApplicationsResponse, GetWKSApplicationCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.Applications;
        }
        
    }
}
