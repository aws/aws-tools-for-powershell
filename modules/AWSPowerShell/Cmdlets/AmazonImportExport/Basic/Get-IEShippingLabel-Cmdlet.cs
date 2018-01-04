/*******************************************************************************
 *  Copyright 2012-2018 Amazon.com, Inc. or its affiliates. All Rights Reserved.
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
using Amazon.ImportExport;
using Amazon.ImportExport.Model;

namespace Amazon.PowerShell.Cmdlets.IE
{
    /// <summary>
    /// This operation generates a pre-paid UPS shipping label that you will use to ship your
    /// device to AWS for processing.
    /// </summary>
    [Cmdlet("Get", "IEShippingLabel")]
    [OutputType("Amazon.ImportExport.Model.GetShippingLabelResponse")]
    [AWSCmdlet("Calls the AWS Import/Export GetShippingLabel API operation.", Operation = new[] {"GetShippingLabel"})]
    [AWSCmdletOutput("Amazon.ImportExport.Model.GetShippingLabelResponse",
        "This cmdlet returns a Amazon.ImportExport.Model.GetShippingLabelResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class GetIEShippingLabelCmdlet : AmazonImportExportClientCmdlet, IExecutor
    {
        
        #region Parameter APIVersion
        /// <summary>
        /// <para>
        /// Documentation for this parameter is not currently available; please refer to the service API documentation.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String APIVersion { get; set; }
        #endregion
        
        #region Parameter City
        /// <summary>
        /// <para>
        /// Documentation for this parameter is not currently available; please refer to the service API documentation.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String City { get; set; }
        #endregion
        
        #region Parameter Company
        /// <summary>
        /// <para>
        /// Documentation for this parameter is not currently available; please refer to the service API documentation.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String Company { get; set; }
        #endregion
        
        #region Parameter Country
        /// <summary>
        /// <para>
        /// Documentation for this parameter is not currently available; please refer to the service API documentation.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String Country { get; set; }
        #endregion
        
        #region Parameter JobId
        /// <summary>
        /// <para>
        /// Documentation for this parameter is not currently available; please refer to the service API documentation.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("JobIds")]
        public System.String[] JobId { get; set; }
        #endregion
        
        #region Parameter Name
        /// <summary>
        /// <para>
        /// Documentation for this parameter is not currently available; please refer to the service API documentation.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String Name { get; set; }
        #endregion
        
        #region Parameter PhoneNumber
        /// <summary>
        /// <para>
        /// Documentation for this parameter is not currently available; please refer to the service API documentation.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String PhoneNumber { get; set; }
        #endregion
        
        #region Parameter PostalCode
        /// <summary>
        /// <para>
        /// Documentation for this parameter is not currently available; please refer to the service API documentation.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String PostalCode { get; set; }
        #endregion
        
        #region Parameter StateOrProvince
        /// <summary>
        /// <para>
        /// Documentation for this parameter is not currently available; please refer to the service API documentation.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String StateOrProvince { get; set; }
        #endregion
        
        #region Parameter Street1
        /// <summary>
        /// <para>
        /// Documentation for this parameter is not currently available; please refer to the service API documentation.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String Street1 { get; set; }
        #endregion
        
        #region Parameter Street2
        /// <summary>
        /// <para>
        /// Documentation for this parameter is not currently available; please refer to the service API documentation.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String Street2 { get; set; }
        #endregion
        
        #region Parameter Street3
        /// <summary>
        /// <para>
        /// Documentation for this parameter is not currently available; please refer to the service API documentation.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String Street3 { get; set; }
        #endregion
        
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var context = new CmdletContext
            {
                Region = this.Region,
                Credentials = this.CurrentCredentials
            };
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            context.APIVersion = this.APIVersion;
            context.City = this.City;
            context.Company = this.Company;
            context.Country = this.Country;
            if (this.JobId != null)
            {
                context.JobIds = new List<System.String>(this.JobId);
            }
            context.Name = this.Name;
            context.PhoneNumber = this.PhoneNumber;
            context.PostalCode = this.PostalCode;
            context.StateOrProvince = this.StateOrProvince;
            context.Street1 = this.Street1;
            context.Street2 = this.Street2;
            context.Street3 = this.Street3;
            
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
            var request = new Amazon.ImportExport.Model.GetShippingLabelRequest();
            
            if (cmdletContext.APIVersion != null)
            {
                request.APIVersion = cmdletContext.APIVersion;
            }
            if (cmdletContext.City != null)
            {
                request.City = cmdletContext.City;
            }
            if (cmdletContext.Company != null)
            {
                request.Company = cmdletContext.Company;
            }
            if (cmdletContext.Country != null)
            {
                request.Country = cmdletContext.Country;
            }
            if (cmdletContext.JobIds != null)
            {
                request.JobIds = cmdletContext.JobIds;
            }
            if (cmdletContext.Name != null)
            {
                request.Name = cmdletContext.Name;
            }
            if (cmdletContext.PhoneNumber != null)
            {
                request.PhoneNumber = cmdletContext.PhoneNumber;
            }
            if (cmdletContext.PostalCode != null)
            {
                request.PostalCode = cmdletContext.PostalCode;
            }
            if (cmdletContext.StateOrProvince != null)
            {
                request.StateOrProvince = cmdletContext.StateOrProvince;
            }
            if (cmdletContext.Street1 != null)
            {
                request.Street1 = cmdletContext.Street1;
            }
            if (cmdletContext.Street2 != null)
            {
                request.Street2 = cmdletContext.Street2;
            }
            if (cmdletContext.Street3 != null)
            {
                request.Street3 = cmdletContext.Street3;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = CallAWSServiceOperation(client, request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = response;
                output = new CmdletOutput
                {
                    PipelineOutput = pipelineOutput,
                    ServiceResponse = response,
                    Notes = notes
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
        
        private Amazon.ImportExport.Model.GetShippingLabelResponse CallAWSServiceOperation(IAmazonImportExport client, Amazon.ImportExport.Model.GetShippingLabelRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Import/Export", "GetShippingLabel");
            try
            {
                #if DESKTOP
                return client.GetShippingLabel(request);
                #elif CORECLR
                // todo: handle AggregateException and extract true service exception for rethrow
                var task = client.GetShippingLabelAsync(request);
                return task.Result;
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
            public System.String APIVersion { get; set; }
            public System.String City { get; set; }
            public System.String Company { get; set; }
            public System.String Country { get; set; }
            public List<System.String> JobIds { get; set; }
            public System.String Name { get; set; }
            public System.String PhoneNumber { get; set; }
            public System.String PostalCode { get; set; }
            public System.String StateOrProvince { get; set; }
            public System.String Street1 { get; set; }
            public System.String Street2 { get; set; }
            public System.String Street3 { get; set; }
        }
        
    }
}
